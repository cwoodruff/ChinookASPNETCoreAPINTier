using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.ViewModels;

namespace Chinook.Domain.Converters
{
    public static class PlaylistCoverter
    {
        public static PlaylistViewModel Convert(Playlist playlist)
        {
            var playlistViewModel = new PlaylistViewModel();
            playlistViewModel.PlaylistId = playlist.PlaylistId;
            playlistViewModel.Name = playlist.Name;
            return playlistViewModel;
        }
        
        public static List<PlaylistViewModel> ConvertList(IEnumerable<Playlist> playlists)
        {
            return playlists.Select(p =>
                {
                    var model = new PlaylistViewModel();
                    model.PlaylistId = p.PlaylistId;
                    model.Name = p.Name;
                    return model;
                })
                .ToList();
        }
    }
}