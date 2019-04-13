using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Responses;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<List<TrackResponse>> GetAllTrackAsync(CancellationToken ct = default(CancellationToken))
        {
            var tracks = TrackCoverter.ConvertList(await _trackRepository.GetAllAsync(ct));
            return tracks;
        }

        public async Task<TrackResponse> GetTrackByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var trackViewModel = TrackCoverter.Convert(await _trackRepository.GetByIdAsync(id, ct));
            trackViewModel.Genre = await GetGenreByIdAsync(trackViewModel.GenreId.GetValueOrDefault(), ct);
            trackViewModel.Album = await GetAlbumByIdAsync(trackViewModel.AlbumId, ct);
            trackViewModel.MediaType = await GetMediaTypeByIdAsync(trackViewModel.MediaTypeId, ct);
            trackViewModel.AlbumName = trackViewModel.Album.Title;
            trackViewModel.MediaTypeName = trackViewModel.MediaType.Name;
            trackViewModel.GenreName = trackViewModel.Genre.Name;
            return trackViewModel;
        }

        public async Task<List<TrackResponse>> GetTrackByAlbumIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var tracks = await _trackRepository.GetByAlbumIdAsync(id, ct);
            return TrackCoverter.ConvertList(tracks).ToList();
        }

        public async Task<List<TrackResponse>> GetTrackByGenreIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var tracks = await _trackRepository.GetByGenreIdAsync(id, ct);
            return TrackCoverter.ConvertList(tracks).ToList();
        }

        public async Task<List<TrackResponse>> GetTrackByMediaTypeIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var tracks = await _trackRepository.GetByMediaTypeIdAsync(id, ct);
            return TrackCoverter.ConvertList(tracks).ToList();
        }

        public async Task<List<TrackResponse>> GetTrackByPlaylistIdIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var tracks = await _playlistRepository.GetTrackByPlaylistIdAsync(id, ct);
            return TrackCoverter.ConvertList(tracks).ToList();
        }

        public async Task<TrackResponse> AddTrackAsync(TrackResponse newTrackViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var track = new Track
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
            };

            await _trackRepository.AddAsync(track, ct);
            newTrackViewModel.TrackId = track.TrackId;
            return newTrackViewModel;
        }

        public async Task<bool> UpdateTrackAsync(TrackResponse trackViewModel,
            CancellationToken ct = default(CancellationToken))
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

        public async Task<bool> DeleteTrackAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _trackRepository.DeleteAsync(id, ct);
        }
    }
}