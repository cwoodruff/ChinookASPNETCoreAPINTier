using System;
using System.Collections.Generic;

namespace Chinook.Domain.Responses
{
    public sealed class InvoiceResponse
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public decimal Total { get; set; }

        public IList<InvoiceLineResponse> InvoiceLines { get; set; }
        public CustomerResponse Customer { get; set; }
    }
}