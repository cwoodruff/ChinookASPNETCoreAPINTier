using Chinook.Domain.Converters;
using Chinook.Domain.Responses;
using System.Collections.Generic;

namespace Chinook.Domain.Entities
{
    public class Genre : IConvertModel<Genre, GenreResponse>
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();

        public GenreResponse Convert => new GenreResponse
        {
            GenreId = GenreId,
            Name = Name
        };
    }
}