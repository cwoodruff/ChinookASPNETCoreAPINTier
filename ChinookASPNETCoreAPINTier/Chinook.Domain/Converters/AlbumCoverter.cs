using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.ViewModels;

namespace Chinook.Domain.Converters
{
    public static class AlbumCoverter
    {
        public static AlbumViewModel Convert(Album album)
        {
            var albumViewModel = new AlbumViewModel();
            albumViewModel.AlbumId = album.AlbumId;
            albumViewModel.ArtistId = album.ArtistId;
            albumViewModel.Title = album.Title;

            return albumViewModel;
        }
        
        public static List<AlbumViewModel> ConvertList(IEnumerable<Album> albums)
        {
            return albums.Select(a =>
                {
                    var model = new AlbumViewModel();
                    model.AlbumId = a.AlbumId;
                    model.ArtistId = a.ArtistId;
                    model.Title = a.Title;
                    return model;
                })
                .ToList();
        }
    }
}