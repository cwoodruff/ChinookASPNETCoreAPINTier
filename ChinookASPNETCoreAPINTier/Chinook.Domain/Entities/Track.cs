using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class Track : IConvertModel<Track, TrackApiModel>
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TrackId { get; set; }

        public string Name { get; set; }

        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<InvoiceLine> InvoiceLines { get; set; } = new HashSet<InvoiceLine>();
        [NotMapped]
        [JsonIgnore]
        public ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new HashSet<PlaylistTrack>();
        [NotMapped]
        [JsonIgnore]
        public Album Album { get; set; }
        [NotMapped]
        [JsonIgnore]
        public Genre Genre { get; set; }
        [NotMapped]
        [JsonIgnore]
        public MediaType MediaType { get; set; }

        public TrackApiModel Convert() => new TrackApiModel
        {
            TrackId = TrackId,
            Name = Name,
            AlbumId = AlbumId,
            MediaTypeId = MediaTypeId,
            GenreId = GenreId,
            Composer = Composer,
            Milliseconds = Milliseconds,
            Bytes = Bytes,
            UnitPrice = UnitPrice
        };
    }
}