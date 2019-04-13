using System.Collections.Generic;

namespace Chinook.Domain.Responses
{
    public class GenreResponse
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public IList<TrackResponse> Tracks { get; set; }
    }
}