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

        public async Task<List<Artist>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            IList<Artist> list = new List<Artist>();

            var artist = new Artist
            {
                ArtistId = 1,
                Name = "Foo"
            };
            list.Add(artist);
            return list.ToList();
        }

        public async Task<Artist> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var artist = new Artist
            {
                ArtistId = id,
                Name = "Foo"
            };
            return artist;
        }

        public async Task<Artist> AddAsync(Artist newArtist, CancellationToken ct = default(CancellationToken))
        {
            return newArtist;
        }

        public async Task<bool> UpdateAsync(Artist artist, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }
    }
}
