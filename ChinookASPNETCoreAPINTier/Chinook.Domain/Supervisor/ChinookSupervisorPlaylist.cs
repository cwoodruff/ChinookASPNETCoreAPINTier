using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.ApiModels;
using System.Linq;
using Chinook.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<PlaylistApiModel>> GetAllPlaylistAsync(
            CancellationToken ct = default)
        {
            var playlists = await _playlistRepository.GetAllAsync(ct);
            foreach (var playlist in playlists)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(playlist.PlaylistId, playlist, cacheEntryOptions);
            }
            return playlists.ConvertAll();
        }

        public async Task<PlaylistApiModel> GetPlaylistByIdAsync(int id,
            CancellationToken ct = default)
        {
            var playlist = _cache.Get<Playlist>(id);

            if (playlist != null)
            {
                var playlistApiModel = playlist.Convert();
                playlistApiModel.Tracks = (await GetTrackByPlaylistIdIdAsync(playlistApiModel.PlaylistId, ct)).ToList();
                return playlistApiModel;
            }
            else
            {
                var playlistApiModel = (await _playlistRepository.GetByIdAsync(id, ct)).Convert();
                playlistApiModel.Tracks = (await GetTrackByPlaylistIdIdAsync(playlistApiModel.PlaylistId, ct)).ToList();

                var cacheEntryOptions =
                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(playlistApiModel.PlaylistId, playlistApiModel, cacheEntryOptions);

                return playlistApiModel;
            }
        }

        public async Task<PlaylistApiModel> AddPlaylistAsync(PlaylistApiModel newPlaylistApiModel,
            CancellationToken ct = default)
        {
            /*var playlist = new Playlist
            {
                Name = newPlaylistApiModel.Name
            };*/

            var playlist = newPlaylistApiModel.Convert();

            playlist = await _playlistRepository.AddAsync(playlist, ct);
            newPlaylistApiModel.PlaylistId = playlist.PlaylistId;
            return newPlaylistApiModel;
        }

        public async Task<bool> UpdatePlaylistAsync(PlaylistApiModel playlistApiModel,
            CancellationToken ct = default)
        {
            var playlist = await _playlistRepository.GetByIdAsync(playlistApiModel.PlaylistId, ct);

            if (playlist == null) return false;
            playlist.PlaylistId = playlistApiModel.PlaylistId;
            playlist.Name = playlistApiModel.Name;

            return await _playlistRepository.UpdateAsync(playlist, ct);
        }

        public Task<bool> DeletePlaylistAsync(int id, CancellationToken ct = default) 
            => _playlistRepository.DeleteAsync(id, ct);
    }
}