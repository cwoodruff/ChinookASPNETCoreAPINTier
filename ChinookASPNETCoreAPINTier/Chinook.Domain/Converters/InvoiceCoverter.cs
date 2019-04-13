using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class InvoiceCoverter
    {
        public static InvoiceResponse Convert(Invoice invoice)
        {
            var invoiceViewModel = new InvoiceResponse();
            invoiceViewModel.InvoiceId = invoice.InvoiceId;
            invoiceViewModel.CustomerId = invoice.CustomerId;
            invoiceViewModel.InvoiceDate = invoice.InvoiceDate;
            invoiceViewModel.BillingAddress = invoice.BillingAddress;
            invoiceViewModel.BillingCity = invoice.BillingCity;
            invoiceViewModel.BillingState = invoice.BillingState;
            invoiceViewModel.BillingCountry = invoice.BillingCountry;
            invoiceViewModel.BillingPostalCode = invoice.BillingPostalCode;
            invoiceViewModel.Total = invoice.Total;

            return invoiceViewModel;
        }

        public static List<InvoiceResponse> ConvertList(IEnumerable<Invoice> invoices)
        {
            return invoices.Select(i =>
                {
                    var model = new InvoiceResponse();
                    model.InvoiceId = i.InvoiceId;
                    model.CustomerId = i.CustomerId;
                    model.InvoiceDate = i.InvoiceDate;
                    model.BillingAddress = i.BillingAddress;
                    model.BillingCity = i.BillingCity;
                    model.BillingState = i.BillingState;
                    model.BillingCountry = i.BillingCountry;
                    model.BillingPostalCode = i.BillingPostalCode;
                    model.Total = i.Total;
                    return model;
                })
                .ToList();
        }
    }
}