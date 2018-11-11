using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.DataDapper.Repositories
{
    public class MediaTypeRepository : IMediaTypeRepository
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<MediaType>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<MediaType> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<MediaType> AddAsync(MediaType newMediaType, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateAsync(MediaType mediaType, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }
    }
}