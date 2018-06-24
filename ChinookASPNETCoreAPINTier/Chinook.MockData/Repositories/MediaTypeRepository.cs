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

        public async Task<List<MediaType>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            IList<MediaType> list = new List<MediaType>();
            var mediaType = new MediaType
            {
                MediaTypeId = 1,
                Name = "Foo"
            };
            list.Add(mediaType);
            return list.ToList();
        }

        public async Task<MediaType> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var mediaType = new MediaType
            {
                MediaTypeId = id,
                Name = "Foo"
            };
            return mediaType;
        }

        public async Task<MediaType> AddAsync(MediaType newMediaType, CancellationToken ct = default(CancellationToken))
        {
            return newMediaType;
        }

        public async Task<bool> UpdateAsync(MediaType mediaType, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }
    }
}
