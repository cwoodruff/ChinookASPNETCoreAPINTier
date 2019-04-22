using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.ApiModels;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;
using System.Linq;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<PlaylistApiModel>> GetAllPlaylistAsync(
            CancellationToken ct = default)
        {
            var playlists = await _playlistRepository.GetAllAsync(ct);
            return playlists.ConvertAll();
        }

        public async Task<PlaylistApiModel> GetPlaylistByIdAsync(int id,
            CancellationToken ct = default)
        {
            var playlistViewModel = (await _playlistRepository.GetByIdAsync(id, ct)).Convert;
            playlistViewModel.Tracks = (await GetTrackByPlaylistIdIdAsync(playlistViewModel.PlaylistId, ct)).ToList();
            return playlistViewModel;
        }

        public async Task<PlaylistApiModel> AddPlaylistAsync(PlaylistApiModel newPlaylistViewModel,
            CancellationToken ct = default)
        {
            var playlist = newPlaylistViewModel.Convert;

            playlist = await _playlistRepository.AddAsync(playlist, ct);
            newPlaylistViewModel.PlaylistId = playlist.PlaylistId;
            return newPlaylistViewModel;
        }

        public async Task<bool> UpdatePlaylistAsync(PlaylistApiModel playlistViewModel,
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