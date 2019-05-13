using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class PlaylistValidator : AbstractValidator<PlaylistApiModel>
    {
        public PlaylistValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}