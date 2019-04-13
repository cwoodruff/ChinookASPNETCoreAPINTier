using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Responses;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<List<PlaylistResponse>> GetAllPlaylistAsync(
            CancellationToken ct = default(CancellationToken))
        {
            var playlists = PlaylistCoverter.ConvertList(await _playlistRepository.GetAllAsync(ct));
            return playlists;
        }

        public async Task<PlaylistResponse> GetPlaylistByIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var playlistViewModel = PlaylistCoverter.Convert(await _playlistRepository.GetByIdAsync(id, ct));
            playlistViewModel.Tracks = await GetTrackByPlaylistIdIdAsync(playlistViewModel.PlaylistId, ct);
            return playlistViewModel;
        }

        public async Task<PlaylistResponse> AddPlaylistAsync(PlaylistResponse newPlaylistViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var playlist = new Playlist
            {
                Name = newPlaylistViewModel.Name
            };

            playlist = await _playlistRepository.AddAsync(playlist, ct);
            newPlaylistViewModel.PlaylistId = playlist.PlaylistId;
            return newPlaylistViewModel;
        }

        public async Task<bool> UpdatePlaylistAsync(PlaylistResponse playlistViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var playlist = await _playlistRepository.GetByIdAsync(playlistViewModel.PlaylistId, ct);

            if (playlist == null) return false;
            playlist.PlaylistId = playlistViewModel.PlaylistId;
            playlist.Name = playlistViewModel.Name;

            return await _playlistRepository.UpdateAsync(playlist, ct);
        }

        public async Task<bool> DeletePlaylistAsync(int id, CancellationToken ct = default(CancellationToken)) => await _playlistRepository.DeleteAsync(id, ct);
    }
}