using System.Collections.Generic;

namespace Chinook.Domain.Responses
{
    public class MediaTypeResponse
    {
        public int MediaTypeId { get; set; }
        public string Name { get; set; }

        public IList<TrackResponse> Tracks { get; set; }
    }
}