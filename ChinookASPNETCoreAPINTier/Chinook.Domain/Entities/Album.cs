using System.Collections.Generic;

namespace Chinook.Domain.Entities
{
    public sealed class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        
        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
        public Artist Artist { get; set; }
    }
}
