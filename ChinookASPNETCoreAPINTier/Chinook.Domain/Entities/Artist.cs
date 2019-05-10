using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class Artist : IConvertModel<Artist, ArtistApiModel>
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; } = new HashSet<Album>();

        [JsonIgnore]
        public ArtistApiModel Convert => new ArtistApiModel
        {
            ArtistId = ArtistId,
            Name = Name
        };
    }
}