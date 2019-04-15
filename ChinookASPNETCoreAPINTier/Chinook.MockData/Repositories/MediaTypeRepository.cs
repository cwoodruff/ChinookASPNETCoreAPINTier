using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.MockData.Repositories
{
    public class MediaTypeRepository : IMediaTypeRepository
    {
        public void Dispose()
        {
        }

        public Task<List<MediaType>> GetAllAsync(CancellationToken ct = default)
            => new MediaType
            {
                MediaTypeId = 1,
                Name = "Foo"
            }.AsListTask();

        public Task<MediaType> GetByIdAsync(int id, CancellationToken ct = default)
            => new MediaType
            {
                MediaTypeId = id,
                Name = "Foo"
            }.AsTask();

        public Task<MediaType> AddAsync(MediaType newMediaType, CancellationToken ct = default) => newMediaType.AsTask();

        public Task<bool> UpdateAsync(MediaType mediaType, CancellationToken ct = default) => true.AsTask();

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true.AsTask();
    }
}