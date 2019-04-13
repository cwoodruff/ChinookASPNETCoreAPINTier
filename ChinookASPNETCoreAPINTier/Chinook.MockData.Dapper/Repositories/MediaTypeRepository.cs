using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.MockData.Dapper.Repositories
{
    public class MediaTypeRepository : IMediaTypeRepository
    {
        public void Dispose()
        {
        }

        public async Task<List<MediaType>> GetAllAsync(CancellationToken ct = default)
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

        public async Task<MediaType> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var mediaType = new MediaType
            {
                MediaTypeId = id,
                Name = "Foo"
            };
            return mediaType;
        }

        public async Task<MediaType> AddAsync(MediaType newMediaType, CancellationToken ct = default) => newMediaType;

        public async Task<bool> UpdateAsync(MediaType mediaType, CancellationToken ct = default) => true;

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true;
    }
}