using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.MockData.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        public void Dispose()
        {
        }

        public Task<List<Album>> GetAllAsync(CancellationToken ct = default)
            => new Album
            {
                AlbumId = 1,
                ArtistId = 1,
                Title = "Hello World"
            }.AsListTask();

        public Task<Album> GetByIdAsync(int id, CancellationToken ct = default)
            => new Album
            {
                AlbumId = id,
                ArtistId = 1,
                Title = "Hello World"
            }.AsTask();

        public Task<Album> AddAsync(Album newAlbum, CancellationToken ct = default)
        {
            newAlbum.AlbumId = 1;
            return newAlbum.AsTask();
        }

        public Task<bool> UpdateAsync(Album album, CancellationToken ct = default) => Task.FromResult(true);

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default) => Task.FromResult(true);

        public Task<List<Album>> GetByArtistIdAsync(int id, CancellationToken ct = default)
            => new Album
            {
                Title = "hello World",
                ArtistId = 1,
                AlbumId = 1
            }.AsListTask();
    }
}