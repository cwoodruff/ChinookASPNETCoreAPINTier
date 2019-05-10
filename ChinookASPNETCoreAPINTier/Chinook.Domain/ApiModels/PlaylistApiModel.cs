using System.Collections.Generic;
using Chinook.Domain.Entities;
using Newtonsoft.Json;

namespace Chinook.Domain.ApiModels
{
    public class PlaylistApiModel
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public IList<TrackApiModel> Tracks { get; set; }
        public IList<PlaylistTrackApiModel> PlaylistTracks { get; set; }
        
        [JsonIgnore]
        public Playlist Convert => new Playlist
        {
            PlaylistId = PlaylistId,
            Name = Name
        };
    }
}