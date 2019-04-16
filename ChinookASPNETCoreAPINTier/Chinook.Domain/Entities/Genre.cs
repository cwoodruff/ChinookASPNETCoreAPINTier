using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System.Collections.Generic;

namespace Chinook.Domain.Entities
{
    public class Genre : IConvertModel<Genre, GenreApiModel>
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();

        public GenreApiModel Convert => new GenreApiModel
        {
            GenreId = GenreId,
            Name = Name
        };
    }
}