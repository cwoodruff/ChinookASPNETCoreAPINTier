using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;
using Newtonsoft.Json;

namespace Chinook.Domain.ApiModels
{
    public class ArtistApiModel : IConvertModel<ArtistApiModel, Artist>
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ArtistId { get; set; }

        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IList<AlbumApiModel> Albums { get; set; }
        
        public Artist Convert() => new Artist
        {
            ArtistId = ArtistId,
            Name = Name
        };
    }
}