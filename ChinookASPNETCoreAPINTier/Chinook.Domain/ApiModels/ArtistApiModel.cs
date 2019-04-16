using System.Collections.Generic;

namespace Chinook.Domain.ApiModels
{
    public class ArtistApiModel
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public IList<AlbumApiModel> Albums { get; set; }
    }
}