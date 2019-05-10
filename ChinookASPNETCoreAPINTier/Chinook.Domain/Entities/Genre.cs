using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class Genre : IConvertModel<Genre, GenreApiModel>
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();

        [JsonIgnore]
        public GenreApiModel Convert => new GenreApiModel
        {
            GenreId = GenreId,
            Name = Name
        };
    }
}