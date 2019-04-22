using System.Collections.Generic;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels
{
    public class GenreApiModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public IList<TrackApiModel> Tracks { get; set; }

        public Genre Convert => new Genre
        {
            GenreId = GenreId,
            Name = Name
        };
    }
}