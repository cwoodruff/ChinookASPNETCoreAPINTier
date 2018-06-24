using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.ViewModels;

namespace Chinook.Domain.Converters
{
    public static class MediaTypeCoverter
    {
        public static MediaTypeViewModel Convert(MediaType mediaType)
        {
            var mediaTypeViewModel = new MediaTypeViewModel();
            mediaTypeViewModel.MediaTypeId = mediaType.MediaTypeId;
            mediaTypeViewModel.Name = mediaType.Name;
            return mediaTypeViewModel;
        }
        
        public static List<MediaTypeViewModel> ConvertList(IEnumerable<MediaType> mediaTypes)
        {
            return mediaTypes.Select(m =>
                {
                    var model = new MediaTypeViewModel();
                    model.MediaTypeId = m.MediaTypeId;
                    model.Name = m.Name;
                    return model;
                })
                .ToList();
        }
    }
}