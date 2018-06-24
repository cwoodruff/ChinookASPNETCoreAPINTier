using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.ViewModels;

namespace Chinook.Domain.Converters
{
    public static class GenreCoverter
    {
        public static GenreViewModel Convert(Genre genre)
        {
            var genreViewModel = new GenreViewModel();
            genreViewModel.GenreId = genre.GenreId;
            genreViewModel.Name = genre.Name;

            return genreViewModel;
        }
        
        public static List<GenreViewModel> ConvertList(IEnumerable<Genre> genres)
        {
            return genres.Select(g =>
                {
                    var model = new GenreViewModel();
                    model.GenreId = g.GenreId;
                    model.Name = g.Name;
                    return model;
                })
                .ToList();
        }
    }
}