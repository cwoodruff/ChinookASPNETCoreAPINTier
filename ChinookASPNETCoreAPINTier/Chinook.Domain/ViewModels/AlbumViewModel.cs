using System.Collections.Generic;

namespace Chinook.Domain.ViewModels
{
    public class AlbumViewModel
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }

        public ArtistViewModel Artist { get; set; }
        public IList<TrackViewModel> Tracks { get; set; }

    }
}
