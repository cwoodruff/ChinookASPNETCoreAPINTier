namespace Chinook.Domain.Responses
{
    public class PlaylistTrackResponse
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }

        public PlaylistResponse Playlist { get; set; }
        public TrackResponse Track { get; set; }
    }
}