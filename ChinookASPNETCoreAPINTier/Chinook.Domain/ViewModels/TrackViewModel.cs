using System.Collections.Generic;

namespace Chinook.Domain.ViewModels
{
    public sealed class TrackViewModel
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

        public IList<InvoiceLineViewModel> InvoiceLines { get; set; }
        public IList<PlaylistTrackViewModel> PlaylistTracks { get; set; }
        public AlbumViewModel Album { get; set; }
        public GenreViewModel Genre { get; set; }
        public MediaTypeViewModel MediaType { get; set; }
    }
}
