using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class MediaTypeCoverter
    {
        public static MediaTypeResponse Convert(MediaType mediaType)
        {
            var mediaTypeViewModel = new MediaTypeResponse();
            mediaTypeViewModel.MediaTypeId = mediaType.MediaTypeId;
            mediaTypeViewModel.Name = mediaType.Name;
            return mediaTypeViewModel;
        }

        public static List<MediaTypeResponse> ConvertList(IEnumerable<MediaType> mediaTypes)
        {
            return mediaTypes.Select(m =>
                {
                    var model = new MediaTypeResponse();
                    model.MediaTypeId = m.MediaTypeId;
                    model.Name = m.Name;
                    return model;
                })
                .ToList();
        }
    }
}