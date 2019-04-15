using Chinook.Domain.Converters;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Entities
{
    public class InvoiceLine : IConvertModel<InvoiceLine, InvoiceLineResponse>
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public Invoice Invoice { get; set; }
        public Track Track { get; set; }

        public InvoiceLineResponse Convert => new InvoiceLineResponse
        {
            InvoiceLineId = InvoiceLineId,
            InvoiceId = InvoiceId,
            TrackId = TrackId,
            UnitPrice = UnitPrice,
            Quantity = Quantity
        };
    }
}