namespace Chinook.Domain.ViewModels
{
    public class PlaylistTrackViewModel
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }

        public PlaylistViewModel Playlist { get; set; }
        public TrackViewModel Track { get; set; }
    }
}
