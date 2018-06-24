using System;
using System.Collections.Generic;
using Chinook.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Domain.Repositories
{
    public interface IArtistRepository : IDisposable
    {
        Task<List<Artist>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<Artist> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<Artist> AddAsync(Artist newArtist, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(Artist artist, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}
