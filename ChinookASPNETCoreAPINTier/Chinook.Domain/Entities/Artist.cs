using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class Artist : IConvertModel<Artist, ArtistApiModel>
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ArtistId { get; set; }
        
        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<Album> Albums { get; set; } = new HashSet<Album>();

        public ArtistApiModel Convert() => new ArtistApiModel
        {
            ArtistId = ArtistId,
            Name = Name
        };
    }
}