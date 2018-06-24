using System.Collections.Generic;

namespace Chinook.Domain.ViewModels
{
    public class PlaylistViewModel
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public IList<TrackViewModel> Tracks { get; set; }
        public IList<PlaylistTrackViewModel> PlaylistTracks { get; set; }
    }
}
