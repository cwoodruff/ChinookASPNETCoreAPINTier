using System.Collections.Generic;

namespace Chinook.Domain.Responses
{
    public sealed class TrackResponse
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

        public IList<InvoiceLineResponse> InvoiceLines { get; set; }
        public IList<PlaylistTrackResponse> PlaylistTracks { get; set; }
        public AlbumResponse Album { get; set; }
        public GenreResponse Genre { get; set; }
        public MediaTypeResponse MediaType { get; set; }
    }
}