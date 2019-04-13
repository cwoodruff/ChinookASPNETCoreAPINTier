using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class GenreCoverter
    {
        public static GenreResponse Convert(Genre genre)
        {
            var genreViewModel = new GenreResponse();
            genreViewModel.GenreId = genre.GenreId;
            genreViewModel.Name = genre.Name;

            return genreViewModel;
        }

        public static List<GenreResponse> ConvertList(IEnumerable<Genre> genres)
        {
            return genres.Select(g =>
                {
                    var model = new GenreResponse();
                    model.GenreId = g.GenreId;
                    model.Name = g.Name;
                    return model;
                })
                .ToList();
        }
    }
}