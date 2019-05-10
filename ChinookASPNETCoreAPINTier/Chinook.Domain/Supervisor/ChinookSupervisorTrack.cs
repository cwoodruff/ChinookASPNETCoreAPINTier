using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.ApiModels;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<TrackApiModel>> GetAllTrackAsync(CancellationToken ct = default)
        {
            var tracks = await _trackRepository.GetAllAsync(ct);
            return tracks.ConvertAll();
        }

        public async Task<TrackApiModel> GetTrackByIdAsync(int id, CancellationToken ct = default)
        {
            var trackViewModel = (await _trackRepository.GetByIdAsync(id, ct)).Convert;
            trackViewModel.Genre = await GetGenreByIdAsync(trackViewModel.GenreId.GetValueOrDefault(), ct);
            trackViewModel.Album = await GetAlbumByIdAsync(trackViewModel.AlbumId, ct);
            trackViewModel.MediaType = await GetMediaTypeByIdAsync(trackViewModel.MediaTypeId, ct);
            trackViewModel.AlbumName = trackViewModel.Album.Title;
            trackViewModel.MediaTypeName = trackViewModel.MediaType.Name;
            trackViewModel.GenreName = trackViewModel.Genre.Name;
            return trackViewModel;
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

        public async Task<TrackApiModel> AddTrackAsync(TrackApiModel newTrackViewModel,
            CancellationToken ct = default)
        {
            /*var track = new Track
            {
                TrackId = newTrackViewModel.TrackId,
                Name = newTrackViewModel.Name,
                AlbumId = newTrackViewModel.AlbumId,
                MediaTypeId = newTrackViewModel.MediaTypeId,
                GenreId = newTrackViewModel.GenreId,
                Composer = newTrackViewModel.Composer,
                Milliseconds = newTrackViewModel.Milliseconds,
                Bytes = newTrackViewModel.Bytes,
                UnitPrice = newTrackViewModel.UnitPrice
            };*/

            var track = newTrackViewModel.Convert;

            await _trackRepository.AddAsync(track, ct);
            newTrackViewModel.TrackId = track.TrackId;
            return newTrackViewModel;
        }

        public async Task<bool> UpdateTrackAsync(TrackApiModel trackViewModel,
            CancellationToken ct = default)
        {
            var track = await _trackRepository.GetByIdAsync(trackViewModel.TrackId, ct);

            if (track == null) return false;
            track.TrackId = trackViewModel.TrackId;
            track.Name = trackViewModel.Name;
            track.AlbumId = trackViewModel.AlbumId;
            track.MediaTypeId = trackViewModel.MediaTypeId;
            track.GenreId = trackViewModel.GenreId;
            track.Composer = trackViewModel.Composer;
            track.Milliseconds = trackViewModel.Milliseconds;
            track.Bytes = trackViewModel.Bytes;
            track.UnitPrice = trackViewModel.UnitPrice;

            return await _trackRepository.UpdateAsync(track, ct);
        }

        public Task<bool> DeleteTrackAsync(int id, CancellationToken ct = default) 
            => _trackRepository.DeleteAsync(id, ct);
    }
}