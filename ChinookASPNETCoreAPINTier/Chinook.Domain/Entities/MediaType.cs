using Chinook.Domain.Converters;
using Chinook.Domain.Responses;
using System.Collections.Generic;

namespace Chinook.Domain.Entities
{
    public class MediaType : IConvertModel<MediaType, MediaTypeResponse>
    {
        public int MediaTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();

        public MediaTypeResponse Convert => new MediaTypeResponse
        {
            MediaTypeId = MediaTypeId,
            Name = Name
        };
    }
}