using System.Collections.Generic;

namespace Chinook.Domain.Responses
{
    public class ArtistResponse
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public IList<AlbumResponse> Albums { get; set; }
    }
}