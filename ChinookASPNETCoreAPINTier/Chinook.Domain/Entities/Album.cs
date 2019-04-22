using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System;
using System.Collections.Generic;

namespace Chinook.Domain.Entities
{
    public sealed class Album : IConvertModel<Album, AlbumApiModel>
    {
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public int ArtistId { get; set; }

        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();

        public Artist Artist { get; set; }

        public AlbumApiModel Convert => new AlbumApiModel
        {
            AlbumId = AlbumId,
            ArtistId = ArtistId,
            Title = Title,
            ArtistName = this.Artist.Name
        };
    }
}