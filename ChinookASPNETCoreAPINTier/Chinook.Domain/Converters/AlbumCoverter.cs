using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class AlbumCoverter
    {
        public static AlbumResponse Convert(Album album)
        {
            var albumViewModel = new AlbumResponse();
            albumViewModel.AlbumId = album.AlbumId;
            albumViewModel.ArtistId = album.ArtistId;
            albumViewModel.Title = album.Title;

            return albumViewModel;
        }

        public static List<AlbumResponse> ConvertList(IEnumerable<Album> albums)
        {
            return albums.Select(a =>
                {
                    var model = new AlbumResponse();
                    model.AlbumId = a.AlbumId;
                    model.ArtistId = a.ArtistId;
                    model.Title = a.Title;
                    return model;
                })
                .ToList();
        }
    }
}