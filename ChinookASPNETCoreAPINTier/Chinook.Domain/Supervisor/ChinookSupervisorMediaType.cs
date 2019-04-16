using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.Responses;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;
using System.Linq;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<MediaTypeResponse>> GetAllMediaTypeAsync(
            CancellationToken ct = default)
        {
            var mediaTypes = await _mediaTypeRepository.GetAllAsync(ct);
            return mediaTypes.ConvertAll();
        }

        public async Task<MediaTypeResponse> GetMediaTypeByIdAsync(int id,
            CancellationToken ct = default)
        {
            var mediaTypeViewModel = (await _mediaTypeRepository.GetByIdAsync(id, ct)).Convert;
            mediaTypeViewModel.Tracks = (await GetTrackByMediaTypeIdAsync(mediaTypeViewModel.MediaTypeId, ct)).ToList();
            return mediaTypeViewModel;
        }

        public async Task<MediaTypeResponse> AddMediaTypeAsync(MediaTypeResponse newMediaTypeViewModel,
            CancellationToken ct = default)
        {
            var mediaType = new MediaType
            {
                Name = newMediaTypeViewModel.Name
            };

            mediaType = await _mediaTypeRepository.AddAsync(mediaType, ct);
            newMediaTypeViewModel.MediaTypeId = mediaType.MediaTypeId;
            return newMediaTypeViewModel;
        }

        public async Task<bool> UpdateMediaTypeAsync(MediaTypeResponse mediaTypeViewModel,
            CancellationToken ct = default)
        {
            var mediaType = await _mediaTypeRepository.GetByIdAsync(mediaTypeViewModel.MediaTypeId, ct);

            if (mediaType == null) return false;
            mediaType.MediaTypeId = mediaTypeViewModel.MediaTypeId;
            mediaType.Name = mediaTypeViewModel.Name;

            return await _mediaTypeRepository.UpdateAsync(mediaType, ct);
        }

        public Task<bool> DeleteMediaTypeAsync(int id, CancellationToken ct = default) 
            => _mediaTypeRepository.DeleteAsync(id, ct);
    }
}