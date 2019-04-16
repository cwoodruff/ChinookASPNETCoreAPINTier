using System.Collections.Generic;

namespace Chinook.Domain.ApiModels
{
    public class GenreApiModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public IList<TrackApiModel> Tracks { get; set; }
    }
}