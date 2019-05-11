using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class MediaTypeValidator : AbstractValidator<MediaTypeApiModel>
    {
        public MediaTypeValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
        }
    }
}