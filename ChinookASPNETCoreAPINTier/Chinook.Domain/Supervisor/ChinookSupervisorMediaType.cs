using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.ApiModels;
using System.Linq;
using Chinook.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<MediaTypeApiModel>> GetAllMediaTypeAsync(
            CancellationToken ct = default)
        {
            var mediaTypes = await _mediaTypeRepository.GetAllAsync(ct);
            foreach (var mediaType in mediaTypes)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(mediaType.MediaTypeId, mediaType, cacheEntryOptions);
            }
            return mediaTypes.ConvertAll();
        }

        public async Task<MediaTypeApiModel> GetMediaTypeByIdAsync(int id,
            CancellationToken ct = default)
        {
            var mediaType = _cache.Get<MediaType>(id);

            if (mediaType != null)
            {
                var mediaTypeApiModel = mediaType.Convert();
                mediaTypeApiModel.Tracks = (await GetTrackByMediaTypeIdAsync(mediaTypeApiModel.MediaTypeId, ct)).ToList();
                return mediaTypeApiModel;
            }
            else
            {
                var mediaTypeApiModel = (await _mediaTypeRepository.GetByIdAsync(id, ct)).Convert();
                mediaTypeApiModel.Tracks = (await GetTrackByMediaTypeIdAsync(mediaTypeApiModel.MediaTypeId, ct)).ToList();

                var cacheEntryOptions =
                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(mediaTypeApiModel.MediaTypeId, mediaTypeApiModel, cacheEntryOptions);

                return mediaTypeApiModel;
            }
        }

        public async Task<MediaTypeApiModel> AddMediaTypeAsync(MediaTypeApiModel newMediaTypeApiModel,
            CancellationToken ct = default)
        {
            /*var mediaType = new MediaType
            {
                Name = newMediaTypeApiModel.Name
            };*/

            var mediaType = newMediaTypeApiModel.Convert();

            mediaType = await _mediaTypeRepository.AddAsync(mediaType, ct);
            newMediaTypeApiModel.MediaTypeId = mediaType.MediaTypeId;
            return newMediaTypeApiModel;
        }

        public async Task<bool> UpdateMediaTypeAsync(MediaTypeApiModel mediaTypeApiModel,
            CancellationToken ct = default)
        {
            var mediaType = await _mediaTypeRepository.GetByIdAsync(mediaTypeApiModel.MediaTypeId, ct);

            if (mediaType == null) return false;
            mediaType.MediaTypeId = mediaTypeApiModel.MediaTypeId;
            mediaType.Name = mediaTypeApiModel.Name;

            return await _mediaTypeRepository.UpdateAsync(mediaType, ct);
        }

        public Task<bool> DeleteMediaTypeAsync(int id, CancellationToken ct = default) 
            => _mediaTypeRepository.DeleteAsync(id, ct);
    }
}