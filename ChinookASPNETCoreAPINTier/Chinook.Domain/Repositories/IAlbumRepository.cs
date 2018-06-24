using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Repositories
{
    public interface IAlbumRepository : IDisposable
    {
        Task<List<Album>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<Album> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<Album>> GetByArtistIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<Album> AddAsync(Album newAlbum, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(Album album, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}
