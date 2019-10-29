using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.ApiModels;
using Chinook.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<TrackApiModel>> GetAllTrackAsync(CancellationToken ct = default)
        {
            var tracks = await _trackRepository.GetAllAsync(ct);
            foreach (var track in tracks)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(track.TrackId, track, cacheEntryOptions);
            }
            return tracks.ConvertAll();
        }

        public async Task<TrackApiModel> GetTrackByIdAsync(int id, CancellationToken ct = default)
        {
            var track = _cache.Get<Track>(id);

            if (track != null)
            {
                var trackApiModel = track.Convert();
                trackApiModel.Genre = await GetGenreByIdAsync(trackApiModel.GenreId.GetValueOrDefault(), ct);
                trackApiModel.Album = await GetAlbumByIdAsync(trackApiModel.TrackId, ct);
                trackApiModel.MediaType = await GetMediaTypeByIdAsync(trackApiModel.MediaTypeId, ct);
                trackApiModel.AlbumName = trackApiModel.Album.Title;
                trackApiModel.MediaTypeName = trackApiModel.MediaType.Name;
                trackApiModel.GenreName = trackApiModel.Genre.Name;
                return trackApiModel;
            }
            else
            {
                var trackApiModel = (await _trackRepository.GetByIdAsync(id, ct)).Convert();
                trackApiModel.Genre = await GetGenreByIdAsync(trackApiModel.GenreId.GetValueOrDefault(), ct);
                trackApiModel.Album = await GetAlbumByIdAsync(trackApiModel.TrackId, ct);
                trackApiModel.MediaType = await GetMediaTypeByIdAsync(trackApiModel.MediaTypeId, ct);
                trackApiModel.AlbumName = trackApiModel.Album.Title;
                trackApiModel.MediaTypeName = trackApiModel.MediaType.Name;
                trackApiModel.GenreName = trackApiModel.Genre.Name;

                var cacheEntryOptions =
                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(trackApiModel.TrackId, trackApiModel, cacheEntryOptions);

                return trackApiModel;
            }
        }

        public async Task<IEnumerable<TrackApiModel>> GetTrackByAlbumIdAsync(int id,
            CancellationToken ct = default)
        {
            var tracks = await _trackRepository.GetByAlbumIdAsync(id, ct);
            return tracks.ConvertAll();
        }

        public async Task<IEnumerable<TrackApiModel>> GetTrackByGenreIdAsync(int id,
            CancellationToken ct = default)
        {
            var tracks = await _trackRepository.GetByGenreIdAsync(id, ct);
            return tracks.ConvertAll();
        }

        public async Task<IEnumerable<TrackApiModel>> GetTrackByMediaTypeIdAsync(int id,
            CancellationToken ct = default)
        {
            var tracks = await _trackRepository.GetByMediaTypeIdAsync(id, ct);
            return tracks.ConvertAll();
        }

        public async Task<IEnumerable<TrackApiModel>> GetTrackByPlaylistIdIdAsync(int id,
            CancellationToken ct = default)
        {
            var tracks = await _playlistRepository.GetTrackByPlaylistIdAsync(id, ct);
            return tracks.ConvertAll();
        }

        public async Task<TrackApiModel> AddTrackAsync(TrackApiModel newTrackApiModel,
            CancellationToken ct = default)
        {
            /*var track = new Track
            {
                TrackId = newTrackApiModel.TrackId,
                Name = newTrackApiModel.Name,
                AlbumId = newTrackApiModel.AlbumId,
                MediaTypeId = newTrackApiModel.MediaTypeId,
                GenreId = newTrackApiModel.GenreId,
                Composer = newTrackApiModel.Composer,
                Milliseconds = newTrackApiModel.Milliseconds,
                Bytes = newTrackApiModel.Bytes,
                UnitPrice = newTrackApiModel.UnitPrice
            };*/

            var track = newTrackApiModel.Convert();

            await _trackRepository.AddAsync(track, ct);
            newTrackApiModel.TrackId = track.TrackId;
            return newTrackApiModel;
        }

        public async Task<bool> UpdateTrackAsync(TrackApiModel trackApiModel,
            CancellationToken ct = default)
        {
            var track = await _trackRepository.GetByIdAsync(trackApiModel.TrackId, ct);

            if (track == null) return false;
            track.TrackId = trackApiModel.TrackId;
            track.Name = trackApiModel.Name;
            track.AlbumId = trackApiModel.AlbumId;
            track.MediaTypeId = trackApiModel.MediaTypeId;
            track.GenreId = trackApiModel.GenreId;
            track.Composer = trackApiModel.Composer;
            track.Milliseconds = trackApiModel.Milliseconds;
            track.Bytes = trackApiModel.Bytes;
            track.UnitPrice = trackApiModel.UnitPrice;

            return await _trackRepository.UpdateAsync(track, ct);
        }

        public Task<bool> DeleteTrackAsync(int id, CancellationToken ct = default) 
            => _trackRepository.DeleteAsync(id, ct);
    }
}