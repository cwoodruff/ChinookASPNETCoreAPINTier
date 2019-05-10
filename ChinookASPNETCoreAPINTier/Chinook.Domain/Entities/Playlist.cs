using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class Playlist : IConvertModel<Playlist, PlaylistApiModel>
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }

        public ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new HashSet<PlaylistTrack>();

        [JsonIgnore]
        public PlaylistApiModel Convert => new PlaylistApiModel
        {
            PlaylistId = PlaylistId,
            Name = Name
        };
    }
}