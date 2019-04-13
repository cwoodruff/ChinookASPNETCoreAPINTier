using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class GenreCoverter
    {
        public static GenreResponse Convert(Genre genre)
            => new GenreResponse
            {
                GenreId = genre.GenreId,
                Name = genre.Name
            };

        public static List<GenreResponse> ConvertList(IEnumerable<Genre> genres) 
            => genres.Select(Convert).ToList();
    }
}