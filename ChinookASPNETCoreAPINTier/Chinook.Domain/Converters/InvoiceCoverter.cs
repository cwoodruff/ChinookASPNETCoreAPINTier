using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class InvoiceCoverter
    {
        public static InvoiceResponse Convert(Invoice invoice)
            => new InvoiceResponse
            {
                InvoiceId = invoice.InvoiceId,
                CustomerId = invoice.CustomerId,
                InvoiceDate = invoice.InvoiceDate,
                BillingAddress = invoice.BillingAddress,
                BillingCity = invoice.BillingCity,
                BillingState = invoice.BillingState,
                BillingCountry = invoice.BillingCountry,
                BillingPostalCode = invoice.BillingPostalCode,
                Total = invoice.Total
            };

        public static List<InvoiceResponse> ConvertList(IEnumerable<Invoice> invoices) 
            => invoices.Select(Convert).ToList();
    }
}