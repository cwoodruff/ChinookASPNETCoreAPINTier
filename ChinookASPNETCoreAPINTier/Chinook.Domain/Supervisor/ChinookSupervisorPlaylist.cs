using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.Responses;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;
using System.Linq;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<PlaylistResponse>> GetAllPlaylistAsync(
            CancellationToken ct = default)
        {
            var playlists = await _playlistRepository.GetAllAsync(ct);
            return playlists.ConvertAll();
        }

        public async Task<PlaylistResponse> GetPlaylistByIdAsync(int id,
            CancellationToken ct = default)
        {
            var playlistViewModel = (await _playlistRepository.GetByIdAsync(id, ct)).Convert;
            playlistViewModel.Tracks = (await GetTrackByPlaylistIdIdAsync(playlistViewModel.PlaylistId, ct)).ToList();
            return playlistViewModel;
        }

        public async Task<PlaylistResponse> AddPlaylistAsync(PlaylistResponse newPlaylistViewModel,
            CancellationToken ct = default)
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
            CancellationToken ct = default)
        {
            var playlist = await _playlistRepository.GetByIdAsync(playlistViewModel.PlaylistId, ct);

            if (playlist == null) return false;
            playlist.PlaylistId = playlistViewModel.PlaylistId;
            playlist.Name = playlistViewModel.Name;

            return await _playlistRepository.UpdateAsync(playlist, ct);
        }

        public Task<bool> DeletePlaylistAsync(int id, CancellationToken ct = default) 
            => _playlistRepository.DeleteAsync(id, ct);
    }
}