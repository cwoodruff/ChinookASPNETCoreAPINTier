using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.DataDapper.Repositories
{
    public class PlaylistTrackRepository : IPlaylistTrackRepository
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<PlaylistTrack>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<PlaylistTrack>> GetByPlaylistIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<PlaylistTrack>> GetByTrackIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<PlaylistTrack> AddAsync(PlaylistTrack newPlaylistTrack, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateAsync(PlaylistTrack playlistTrack, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }
    }
}