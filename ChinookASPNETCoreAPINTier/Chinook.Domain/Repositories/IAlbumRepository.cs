using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Repositories
{
    public interface IAlbumRepository : IDisposable
    {
        Task<List<Album>> GetAllAsync(CancellationToken ct = default);
        Task<Album> GetByIdAsync(int id, CancellationToken ct = default);
        Task<List<Album>> GetByArtistIdAsync(int id, CancellationToken ct = default);
        Task<Album> AddAsync(Album newAlbum, CancellationToken ct = default);
        Task<bool> UpdateAsync(Album album, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}