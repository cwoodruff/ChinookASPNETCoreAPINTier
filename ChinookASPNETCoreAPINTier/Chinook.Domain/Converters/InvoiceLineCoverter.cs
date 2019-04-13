using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class InvoiceLineCoverter
    {
        public static InvoiceLineResponse Convert(InvoiceLine invoiceLine)
            => new InvoiceLineResponse
            {
                InvoiceLineId = invoiceLine.InvoiceLineId,
                InvoiceId = invoiceLine.InvoiceId,
                TrackId = invoiceLine.TrackId,
                UnitPrice = invoiceLine.UnitPrice,
                Quantity = invoiceLine.Quantity
            };

        public static List<InvoiceLineResponse> ConvertList(IEnumerable<InvoiceLine> invoiceLines) 
            => invoiceLines.Select(Convert).ToList();
    }
}