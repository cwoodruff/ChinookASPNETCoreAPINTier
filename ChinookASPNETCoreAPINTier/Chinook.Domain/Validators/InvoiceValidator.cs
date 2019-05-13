using System;
using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class InvoiceValidator : AbstractValidator<InvoiceApiModel>
    {
        public InvoiceValidator()
        {
            RuleFor(i => i.InvoiceDate).LessThanOrEqualTo(DateTime.Today);
            RuleFor(i => i.CustomerId).NotNull();
            RuleFor(i => i.BillingAddress).NotEmpty();
            RuleFor(i => i.BillingCity).NotEmpty();
            RuleFor(i => i.BillingState).NotEmpty();
            RuleFor(i => i.BillingCountry).NotEmpty();
            RuleFor(i => i.BillingPostalCode).NotEmpty();
            RuleFor(i => i.Total).GreaterThanOrEqualTo(0);
        }
    }
}