using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;
using Newtonsoft.Json;

namespace Chinook.Domain.ApiModels
{
    public class InvoiceLineApiModel : IConvertModel<InvoiceLineApiModel, InvoiceLine>
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InvoiceLineId { get; set; }

        public int InvoiceId { get; set; }

        public int TrackId { get; set; }
        public string TrackName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        [NotMapped]
        [JsonIgnore]
        public InvoiceApiModel Invoice { get; set; }
        [NotMapped]
        [JsonIgnore]
        public TrackApiModel Track { get; set; }
        
        public InvoiceLine Convert() => new InvoiceLine
        {
            InvoiceLineId = InvoiceLineId,
            InvoiceId = InvoiceId,
            TrackId = TrackId,
            UnitPrice = UnitPrice,
            Quantity = Quantity
        };
    }
}