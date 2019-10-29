using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;
using Newtonsoft.Json;

namespace Chinook.Domain.ApiModels
{
    public class MediaTypeApiModel : IConvertModel<MediaTypeApiModel, MediaType>
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MediaTypeId { get; set; }

        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IList<TrackApiModel> Tracks { get; set; }
        
        public MediaType Convert() => new MediaType
        {
            MediaTypeId = MediaTypeId,
            Name = Name
        };
    }
}