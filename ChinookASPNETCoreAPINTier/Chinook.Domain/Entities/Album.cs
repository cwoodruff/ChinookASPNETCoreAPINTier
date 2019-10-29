using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public sealed class Album : IConvertModel<Album, AlbumApiModel>
    {
        private Artist _artist;


        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }


        public string Title { get; set; }

        public int ArtistId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();

        [NotMapped]
        [JsonIgnore]
        public Artist Artist
        {
            get => _artist;
            set => _artist = value;
        }

        public AlbumApiModel Convert() => new AlbumApiModel
        {
            AlbumId = AlbumId,
            ArtistId = ArtistId,
            Title = Title
        };
    }
}