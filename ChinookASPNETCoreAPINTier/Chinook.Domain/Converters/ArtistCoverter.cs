using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class ArtistCoverter
    {
        public static ArtistResponse Convert(Artist artist)
            => new ArtistResponse
            {
                ArtistId = artist.ArtistId,
                Name = artist.Name
            };

        public static List<ArtistResponse> ConvertList(IEnumerable<Artist> artists) 
            => artists.Select(Convert).ToList();
    }
}