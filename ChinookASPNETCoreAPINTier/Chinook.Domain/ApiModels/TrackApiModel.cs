using System.Collections.Generic;
using Chinook.Domain.Entities;
using Newtonsoft.Json;

namespace Chinook.Domain.ApiModels
{
    public sealed class TrackApiModel
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public int MediaTypeId { get; set; }
        public string MediaTypeName { get; set; }
        public int? GenreId { get; set; }
        public string GenreName { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }

        public IList<InvoiceLineApiModel> InvoiceLines { get; set; }
        public IList<PlaylistTrackApiModel> PlaylistTracks { get; set; }
        public AlbumApiModel Album { get; set; }
        public GenreApiModel Genre { get; set; }
        public MediaTypeApiModel MediaType { get; set; }
        
        [JsonIgnore]
        public Track Convert => new Track
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