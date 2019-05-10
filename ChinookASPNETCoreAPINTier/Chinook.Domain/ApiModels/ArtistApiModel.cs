using System.Collections.Generic;
using Chinook.Domain.Entities;
using Newtonsoft.Json;

namespace Chinook.Domain.ApiModels
{
    public class ArtistApiModel
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public IList<AlbumApiModel> Albums { get; set; }
        
        [JsonIgnore]
        public Artist Convert => new Artist
        {
            ArtistId = ArtistId,
            Name = Name
        };
    }
}