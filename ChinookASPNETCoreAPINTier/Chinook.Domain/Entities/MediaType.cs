using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class MediaType : IConvertModel<MediaType, MediaTypeApiModel>
    {
        public int MediaTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();

        [JsonIgnore]
        public MediaTypeApiModel Convert => new MediaTypeApiModel
        {
            MediaTypeId = MediaTypeId,
            Name = Name
        };
    }
}