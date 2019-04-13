using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class PlaylistCoverter
    {
        public static PlaylistResponse Convert(Playlist playlist)
            => new PlaylistResponse
            {
                PlaylistId = playlist.PlaylistId,
                Name = playlist.Name
            };

        public static List<PlaylistResponse> ConvertList(IEnumerable<Playlist> playlists) 
            => playlists.Select(Convert).ToList();
    }
}