using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class Track : IConvertModel<Track, TrackApiModel>
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }

        public ICollection<InvoiceLine> InvoiceLines { get; set; } = new HashSet<InvoiceLine>();
        public ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new HashSet<PlaylistTrack>();
        public Album Album { get; set; }
        public Genre Genre { get; set; }
        public MediaType MediaType { get; set; }

        [JsonIgnore]
        public TrackApiModel Convert => new TrackApiModel
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