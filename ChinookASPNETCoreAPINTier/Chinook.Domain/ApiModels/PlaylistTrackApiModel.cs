namespace Chinook.Domain.ApiModels
{
    public class PlaylistTrackApiModel
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }

        public PlaylistApiModel Playlist { get; set; }
        public TrackApiModel Track { get; set; }
    }
}