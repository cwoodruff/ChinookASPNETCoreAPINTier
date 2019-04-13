using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class PlaylistTrackCoverter
    {
        public static PlaylistTrackResponse Convert(PlaylistTrack playlistTrack)
            => new PlaylistTrackResponse
            {
                PlaylistId = playlistTrack.PlaylistId,
                TrackId = playlistTrack.TrackId
            };

        public static List<PlaylistTrackResponse> ConvertList(IEnumerable<PlaylistTrack> playlistTracks) 
            => playlistTracks.Select(Convert).ToList();
    }
}