using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.ViewModels;

namespace Chinook.Domain.Converters
{
    public static class ArtistCoverter
    {
        public static ArtistViewModel Convert(Artist artist)
        {
            var artistViewModel = new ArtistViewModel();
            artistViewModel.ArtistId = artist.ArtistId;
            artistViewModel.Name = artist.Name;
            return artistViewModel;
        }
        
        public static List<ArtistViewModel> ConvertList(IEnumerable<Artist> artists)
        {
            return artists.Select(a =>
                {
                    var model = new ArtistViewModel();
                    model.ArtistId = a.ArtistId;
                    model.Name = a.Name;
                    return model;
                })
                .ToList();
        }
    }
}