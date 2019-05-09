using System.Collections.Generic;

namespace Chinook.Domain.ApiModels
{
    public class MediaTypeApiModel
    {
        public int MediaTypeId { get; set; }
        public string Name { get; set; }

        public IList<TrackApiModel> Tracks { get; set; }
    }
}