using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.MockData.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        public void Dispose()
        {
        }

        public Task<List<Artist>> GetAllAsync(CancellationToken ct = default)
            => new Artist
            {
                ArtistId = 1,
                Name = "Foo"
            }.AsListTask();

        public Task<Artist> GetByIdAsync(int id, CancellationToken ct = default)
            => new Artist
            {
                ArtistId = id,
                Name = "Foo"
            }.AsTask();

        public Task<Artist> AddAsync(Artist newArtist, CancellationToken ct = default) => Task.FromResult(newArtist);

        public Task<bool> UpdateAsync(Artist artist, CancellationToken ct = default) => Task.FromResult(true);

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default) => Task.FromResult(true);
    }
}