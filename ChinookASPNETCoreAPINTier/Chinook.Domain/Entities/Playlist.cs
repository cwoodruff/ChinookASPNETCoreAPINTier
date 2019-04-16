using Chinook.Domain.Converters;
using Chinook.Domain.Responses;
using System.Collections.Generic;

namespace Chinook.Domain.Entities
{
    public class Playlist : IConvertModel<Playlist, PlaylistResponse>
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }

        public ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new HashSet<PlaylistTrack>();

        public PlaylistResponse Convert => new PlaylistResponse
        {
            PlaylistId = PlaylistId,
            Name = Name
        };
    }
}