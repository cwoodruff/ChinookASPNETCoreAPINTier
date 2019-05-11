using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class InvoiceLineValidator : AbstractValidator<InvoiceLineApiModel>
    {
        public InvoiceLineValidator()
        {
            RuleFor(i => i.InvoiceId).NotNull();
            RuleFor(i => i.TrackId).NotNull();
            RuleFor(i => i.Quantity).GreaterThan(0);
            RuleFor(i => i.UnitPrice).GreaterThan(0);
        }
    }
}