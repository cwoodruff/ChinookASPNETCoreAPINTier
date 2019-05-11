using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class GenreValidator : AbstractValidator<GenreApiModel>
    {
        public GenreValidator()
        {
            RuleFor(g => g.Name).NotEmpty();
        }
    }
}