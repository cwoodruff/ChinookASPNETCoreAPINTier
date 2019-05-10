using Chinook.Domain.Entities;
using Newtonsoft.Json;

namespace Chinook.Domain.ApiModels
{
    public class InvoiceLineApiModel
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public InvoiceApiModel Invoice { get; set; }
        public TrackApiModel Track { get; set; }
        
        [JsonIgnore]
        public InvoiceLine Convert => new InvoiceLine
        {
            InvoiceLineId = InvoiceLineId,
            InvoiceId = InvoiceId,
            TrackId = TrackId,
            UnitPrice = UnitPrice,
            Quantity = Quantity
        };
    }
}