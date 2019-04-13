using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class InvoiceLineCoverter
    {
        public static InvoiceLineResponse Convert(InvoiceLine invoiceLine)
        {
            var invoiceLineViewModel = new InvoiceLineResponse();
            invoiceLineViewModel.InvoiceLineId = invoiceLine.InvoiceLineId;
            invoiceLineViewModel.InvoiceId = invoiceLine.InvoiceId;
            invoiceLineViewModel.TrackId = invoiceLine.TrackId;
            invoiceLineViewModel.UnitPrice = invoiceLine.UnitPrice;
            invoiceLineViewModel.Quantity = invoiceLine.Quantity;

            return invoiceLineViewModel;
        }

        public static List<InvoiceLineResponse> ConvertList(IEnumerable<InvoiceLine> invoiceLines)
        {
            return invoiceLines.Select(i =>
                {
                    var model = new InvoiceLineResponse();
                    model.InvoiceLineId = i.InvoiceLineId;
                    model.InvoiceId = i.InvoiceId;
                    model.TrackId = i.TrackId;
                    model.UnitPrice = i.UnitPrice;
                    model.Quantity = i.Quantity;
                    return model;
                })
                .ToList();
        }
    }
}