using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class PlaylistTrack : IConvertModel<PlaylistTrack, PlaylistTrackApiModel>
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public Playlist Playlist { get; set; }
        [NotMapped]
        [JsonIgnore]
        public Track Track { get; set; }

        public PlaylistTrackApiModel Convert() => new PlaylistTrackApiModel
        {
            PlaylistId = PlaylistId,
            TrackId = TrackId
        };
    }
}