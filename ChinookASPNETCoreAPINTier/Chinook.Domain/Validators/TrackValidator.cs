using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class TrackValidator : AbstractValidator<TrackApiModel>
    {
        public TrackValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.AlbumId).NotNull();
            RuleFor(t => t.GenreId).NotNull();
            RuleFor(t => t.UnitPrice).GreaterThan(0);
            RuleFor(t => t.Composer).NotEmpty();
            RuleFor(t => t.Milliseconds).GreaterThan(0);
            RuleFor(t => t.MediaTypeId).NotNull();
        }
    }
}