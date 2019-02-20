using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.MockData.Dapper.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        public void Dispose()
        {
        }

        public async Task<List<Genre>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            IList<Genre> list = new List<Genre>();

            var genre = new Genre
            {
                GenreId = 1,
                Name = "Foo"
            };
            list.Add(genre);

            return list.ToList();
        }

        public async Task<Genre> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var genre = new Genre
            {
                GenreId = id,
                Name = "Foo"
            };
            return genre;
        }

        public async Task<Genre> AddAsync(Genre newGenre, CancellationToken ct = default(CancellationToken))
        {
            return newGenre;
        }

        public async Task<bool> UpdateAsync(Genre genre, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }
    }
}