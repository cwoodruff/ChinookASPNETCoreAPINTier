using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public sealed class Album : IConvertModel<Album, AlbumApiModel>
    {
        private readonly ILazyLoader _lazyLoader;
        private Artist _artist;

        public Album()
        {
        }

        public Album(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public int AlbumId { get; set; }

        public string Title { get; set; }

        public int ArtistId { get; set; }

        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();

        public Artist Artist
        {
            get => _lazyLoader.Load(this, ref _artist);
            set => _artist = value;
        }

        [JsonIgnore]
        public AlbumApiModel Convert => new AlbumApiModel
        {
            AlbumId = AlbumId,
            ArtistId = ArtistId,
            Title = Title,
            ArtistName = Artist.Name
        };
    }
}