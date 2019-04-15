using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.MockData.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        public void Dispose()
        {
        }

        public Task<List<Genre>> GetAllAsync(CancellationToken ct = default)
            => new Genre
            {
                GenreId = 1,
                Name = "Foo"
            }.AsListTask();

        public Task<Genre> GetByIdAsync(int id, CancellationToken ct = default)
            => new Genre
            {
                GenreId = id,
                Name = "Foo"
            }.AsTask();

        public Task<Genre> AddAsync(Genre newGenre, CancellationToken ct = default) => newGenre.AsTask();

        public Task<bool> UpdateAsync(Genre genre, CancellationToken ct = default) => true.AsTask();

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true.AsTask();
    }
}