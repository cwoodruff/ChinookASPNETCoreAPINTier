using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.MockData.Repositories
{
    public class PlaylistTrackRepository : IPlaylistTrackRepository
    {
        public void Dispose()
        {
        }

        public Task<List<PlaylistTrack>> GetAllAsync(CancellationToken ct = default)
            => new PlaylistTrack
            {
                PlaylistId = 1,
                TrackId = 1
            }.AsListTask();

        public Task<List<PlaylistTrack>> GetByPlaylistIdAsync(int id,
            CancellationToken ct = default)
            => new PlaylistTrack
            {
                PlaylistId = id,
                TrackId = 1
            }.AsListTask();

        public Task<List<PlaylistTrack>> GetByTrackIdAsync(int id,
            CancellationToken ct = default)
            => new PlaylistTrack
            {
                PlaylistId = 1,
                TrackId = id
            }.AsListTask();

        public Task<PlaylistTrack> AddAsync(PlaylistTrack newPlaylistTrack,
            CancellationToken ct = default) => newPlaylistTrack.AsTask();

        public Task<bool> UpdateAsync(PlaylistTrack playlistTrack,
            CancellationToken ct = default) => true.AsTask();

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true.AsTask();
    }
}