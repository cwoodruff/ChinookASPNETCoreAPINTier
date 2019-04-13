using System.Collections.Generic;

namespace Chinook.Domain.Responses
{
    public class AlbumResponse
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }

        public ArtistResponse Artist { get; set; }
        public IList<TrackResponse> Tracks { get; set; }
    }
}