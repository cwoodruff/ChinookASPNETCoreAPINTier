using System;
using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeApiModel>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty();
            RuleFor(e => e.LastName).NotEmpty();
            RuleFor(e => e.Address).NotEmpty();
            RuleFor(e => e.City).NotEmpty();
            RuleFor(e => e.Country).NotEmpty();
            RuleFor(e => e.State).NotEmpty();
            RuleFor(e => e.PostalCode).NotEmpty();
            RuleFor(e => e.Email).EmailAddress();
            RuleFor(e => e.HireDate).LessThanOrEqualTo(DateTime.Today);
            RuleFor(e => e.ReportsTo).NotNull();
        }
    }
}