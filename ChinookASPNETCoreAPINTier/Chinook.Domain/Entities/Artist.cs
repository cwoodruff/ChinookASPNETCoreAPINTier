using Chinook.Domain.Converters;
using Chinook.Domain.Responses;
using System.Collections.Generic;

namespace Chinook.Domain.Entities
{
    public class Artist : IConvertModel<Artist, ArtistResponse>
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; } = new HashSet<Album>();

        public ArtistResponse Convert => new ArtistResponse
        {
            ArtistId = ArtistId,
            Name = Name
        };
    }
}