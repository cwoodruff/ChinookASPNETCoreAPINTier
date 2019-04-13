using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class MediaTypeCoverter
    {
        public static MediaTypeResponse Convert(MediaType mediaType)
            => new MediaTypeResponse
            {
                MediaTypeId = mediaType.MediaTypeId,
                Name = mediaType.Name
            };

        public static List<MediaTypeResponse> ConvertList(IEnumerable<MediaType> mediaTypes) 
            => mediaTypes.Select(Convert).ToList();
    }
}