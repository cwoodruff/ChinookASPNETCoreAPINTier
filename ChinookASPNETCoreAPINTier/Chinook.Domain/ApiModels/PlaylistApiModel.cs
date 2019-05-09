using System.Collections.Generic;

namespace Chinook.Domain.ApiModels
{
    public class PlaylistApiModel
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public IList<TrackApiModel> Tracks { get; set; }
        public IList<PlaylistTrackApiModel> PlaylistTracks { get; set; }
    }
}