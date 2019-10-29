using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;
using Newtonsoft.Json;

namespace Chinook.Domain.ApiModels
{
    public class PlaylistTrackApiModel : IConvertModel<PlaylistTrackApiModel, PlaylistTrack>
    {

        public int PlaylistId { get; set; }

        public int TrackId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public PlaylistApiModel Playlist { get; set; }
        [NotMapped]
        [JsonIgnore]
        public TrackApiModel Track { get; set; }
        
        public PlaylistTrack Convert() => new PlaylistTrack
        {
            PlaylistId = PlaylistId,
            TrackId = TrackId
        };
    }
}