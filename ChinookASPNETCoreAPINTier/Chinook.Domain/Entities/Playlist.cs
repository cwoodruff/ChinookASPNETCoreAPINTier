using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class Playlist : IConvertModel<Playlist, PlaylistApiModel>
    {
        private readonly ILazyLoader _lazyLoader;

        public Playlist()
        {
        }

        public Playlist(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public int PlaylistId { get; set; }
        public string Name { get; set; }

        public ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new HashSet<PlaylistTrack>();

        [JsonIgnore]
        public PlaylistApiModel Convert => new PlaylistApiModel
        {
            PlaylistId = PlaylistId,
            Name = Name
        };
    }
}