using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class PlaylistCoverter
    {
        public static PlaylistResponse Convert(Playlist playlist)
        {
            var playlistViewModel = new PlaylistResponse();
            playlistViewModel.PlaylistId = playlist.PlaylistId;
            playlistViewModel.Name = playlist.Name;
            return playlistViewModel;
        }

        public static List<PlaylistResponse> ConvertList(IEnumerable<Playlist> playlists)
        {
            return playlists.Select(p =>
                {
                    var model = new PlaylistResponse();
                    model.PlaylistId = p.PlaylistId;
                    model.Name = p.Name;
                    return model;
                })
                .ToList();
        }
    }
}