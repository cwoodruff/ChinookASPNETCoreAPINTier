using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.DataDapper.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Artist>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<Artist> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<Artist> AddAsync(Artist newArtist, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Artist artist, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }
    }
}