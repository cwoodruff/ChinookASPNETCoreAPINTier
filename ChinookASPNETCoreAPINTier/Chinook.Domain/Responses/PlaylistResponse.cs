using System.Collections.Generic;

namespace Chinook.Domain.Responses
{
    public class PlaylistResponse
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public IList<TrackResponse> Tracks { get; set; }
        public IList<PlaylistTrackResponse> PlaylistTracks { get; set; }
    }
}