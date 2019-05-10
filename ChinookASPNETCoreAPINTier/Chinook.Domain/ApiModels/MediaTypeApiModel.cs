using System.Collections.Generic;
using Chinook.Domain.Entities;
using Newtonsoft.Json;

namespace Chinook.Domain.ApiModels
{
    public class MediaTypeApiModel
    {
        public int MediaTypeId { get; set; }
        public string Name { get; set; }

        public IList<TrackApiModel> Tracks { get; set; }
        
        [JsonIgnore]
        public MediaType Convert => new MediaType
        {
            MediaTypeId = MediaTypeId,
            Name = Name
        };
    }
}