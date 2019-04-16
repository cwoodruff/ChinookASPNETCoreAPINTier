using Chinook.Domain.Converters;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Entities
{
    public class PlaylistTrack : IConvertModel<PlaylistTrack, PlaylistTrackResponse>
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }

        public Playlist Playlist { get; set; }
        public Track Track { get; set; }

        public PlaylistTrackResponse Convert => new PlaylistTrackResponse
        {
            PlaylistId = PlaylistId,
            TrackId = TrackId
        };
    }
}