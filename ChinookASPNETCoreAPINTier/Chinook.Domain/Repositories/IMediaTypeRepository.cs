using Chinook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Domain.Repositories
{
    public interface IMediaTypeRepository : IDisposable
    {
        Task<List<MediaType>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<MediaType> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<MediaType> AddAsync(MediaType newMediaType, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(MediaType mediaType, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}
