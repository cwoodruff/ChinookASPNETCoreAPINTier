using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class TrackCoverter
    {
        public static TrackResponse Convert(Track track)
            => new TrackResponse
            {
                TrackId = track.TrackId,
                Name = track.Name,
                AlbumId = track.AlbumId,
                MediaTypeId = track.MediaTypeId,
                GenreId = track.GenreId,
                Composer = track.Composer,
                Milliseconds = track.Milliseconds,
                Bytes = track.Bytes,
                UnitPrice = track.UnitPrice
            };

        public static List<TrackResponse> ConvertList(IEnumerable<Track> albums) 
            => albums.Select(Convert).ToList();
    }
}