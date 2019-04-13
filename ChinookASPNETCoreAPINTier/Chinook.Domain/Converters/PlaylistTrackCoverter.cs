using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class PlaylistTrackCoverter
    {
        public static PlaylistTrackResponse Convert(PlaylistTrack playlistTrack)
        {
            var playlistTrackViewModel = new PlaylistTrackResponse();
            playlistTrackViewModel.PlaylistId = playlistTrack.PlaylistId;
            playlistTrackViewModel.TrackId = playlistTrack.TrackId;

            return playlistTrackViewModel;
        }

        public static List<PlaylistTrackResponse> ConvertList(IEnumerable<PlaylistTrack> playlistTracks)
        {
            return playlistTracks.Select(p =>
                {
                    var model = new PlaylistTrackResponse();
                    model.PlaylistId = p.PlaylistId;
                    model.TrackId = p.TrackId;
                    return model;
                })
                .ToList();
        }
    }
}