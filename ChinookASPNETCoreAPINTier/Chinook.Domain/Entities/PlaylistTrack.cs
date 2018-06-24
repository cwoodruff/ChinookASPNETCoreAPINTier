namespace Chinook.Domain.Entities
{
    public class PlaylistTrack
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }
        
        public Playlist Playlist { get; set; }
        public Track Track { get; set; }
    }
}
