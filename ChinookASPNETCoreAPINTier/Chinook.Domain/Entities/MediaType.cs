using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class MediaType : IConvertModel<MediaType, MediaTypeApiModel>
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MediaTypeId { get; set; }

        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();

        public MediaTypeApiModel Convert() => new MediaTypeApiModel
        {
            MediaTypeId = MediaTypeId,
            Name = Name
        };
    }
}