using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class Genre : IConvertModel<Genre, GenreApiModel>
    {
        private readonly ILazyLoader _lazyLoader;

        public Genre()
        {
        }

        public Genre(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public int GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();

        [JsonIgnore]
        public GenreApiModel Convert => new GenreApiModel
        {
            GenreId = GenreId,
            Name = Name
        };
    }
}