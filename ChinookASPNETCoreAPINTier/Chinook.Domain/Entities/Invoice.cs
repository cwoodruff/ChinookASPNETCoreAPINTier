using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class Invoice : IConvertModel<Invoice, InvoiceApiModel>
    {
        private readonly ILazyLoader _lazyLoader;
        private Customer _customer;

        public Invoice()
        {
        }

        public Invoice(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public decimal Total { get; set; }

        public ICollection<InvoiceLine> InvoiceLines { get; set; } = new HashSet<InvoiceLine>();

        public Customer Customer
        {
            get => _lazyLoader.Load(this, ref _customer);
            set => _customer = value;
        }

        [JsonIgnore]
        public InvoiceApiModel Convert => new InvoiceApiModel
        {
            InvoiceId = InvoiceId,
            CustomerId = CustomerId,
            InvoiceDate = InvoiceDate,
            BillingAddress = BillingAddress,
            BillingCity = BillingCity,
            BillingState = BillingState,
            BillingCountry = BillingCountry,
            BillingPostalCode = BillingPostalCode,
            Total = Total,
            CustomerName = Customer.FirstName + " " + Customer.LastName
        };
    }
}