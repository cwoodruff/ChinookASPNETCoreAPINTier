using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class PlaylistTrack : IConvertModel<PlaylistTrack, PlaylistTrackApiModel>
    {
        private readonly ILazyLoader _lazyLoader;

        public PlaylistTrack()
        {
        }

        public PlaylistTrack(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public int PlaylistId { get; set; }
        public int TrackId { get; set; }

        public Playlist Playlist { get; set; }
        public Track Track { get; set; }

        [JsonIgnore]
        public PlaylistTrackApiModel Convert => new PlaylistTrackApiModel
        {
            PlaylistId = PlaylistId,
            TrackId = TrackId
        };
    }
}