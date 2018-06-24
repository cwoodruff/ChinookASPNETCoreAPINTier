using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.ViewModels;

namespace Chinook.Domain.Converters
{
    public static class PlaylistTrackCoverter
    {
        public static PlaylistTrackViewModel Convert(PlaylistTrack playlistTrack)
        {
            var playlistTrackViewModel = new PlaylistTrackViewModel();
            playlistTrackViewModel.PlaylistId = playlistTrack.PlaylistId;
            playlistTrackViewModel.TrackId = playlistTrack.TrackId;

            return playlistTrackViewModel;
        }
        
        public static List<PlaylistTrackViewModel> ConvertList(IEnumerable<PlaylistTrack> playlistTracks)
        {
            return playlistTracks.Select(p =>
                {
                    var model = new PlaylistTrackViewModel();
                    model.PlaylistId = p.PlaylistId;
                    model.TrackId = p.TrackId;
                    return model;
                })
                .ToList();
        }
    }
}