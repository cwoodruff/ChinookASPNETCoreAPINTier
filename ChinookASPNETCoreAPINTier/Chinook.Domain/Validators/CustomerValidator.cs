using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerApiModel>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.City).NotEmpty();
            RuleFor(c => c.Country).NotEmpty();
            RuleFor(c => c.State).NotEmpty();
            RuleFor(c => c.PostalCode).NotEmpty();
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.SupportRepId).NotNull();
        }
    }
}