using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class PlaylistTrack : IConvertModel<PlaylistTrack, PlaylistTrackApiModel>
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }

        public Playlist Playlist { get; set; }
        public Track Track { get; set; }

        [JsonIgnore]
        public PlaylistTrackApiModel Convert => new PlaylistTrackApiModel
        {
            PlaylistId = PlaylistId,
            TrackId = TrackId
        };
    }
}