using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class InvoiceLine : IConvertModel<InvoiceLine, InvoiceLineApiModel>
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public Invoice Invoice { get; set; }
        public Track Track { get; set; }

        [JsonIgnore]
        public InvoiceLineApiModel Convert => new InvoiceLineApiModel
        {
            InvoiceLineId = InvoiceLineId,
            InvoiceId = InvoiceId,
            TrackId = TrackId,
            UnitPrice = UnitPrice,
            Quantity = Quantity
        };
    }
}