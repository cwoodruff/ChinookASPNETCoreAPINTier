using System.Collections.Generic;

namespace Chinook.Domain.ViewModels
{
    public class ArtistViewModel
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public IList<AlbumViewModel> Albums { get; set; }
    }
}
