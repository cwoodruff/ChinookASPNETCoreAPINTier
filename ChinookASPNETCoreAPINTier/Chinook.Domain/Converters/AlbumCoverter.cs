using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class AlbumCoverter
    {
        public static AlbumResponse Convert(Album album)
            => new AlbumResponse
            {
                AlbumId = album.AlbumId,
                ArtistId = album.ArtistId,
                Title = album.Title
            };

        public static List<AlbumResponse> ConvertList(IEnumerable<Album> albums)
            => albums.Select(Convert).ToList();
    }
}