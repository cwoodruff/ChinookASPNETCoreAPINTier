using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class PlaylistTrackValidator : AbstractValidator<PlaylistTrackApiModel>
    {
        public PlaylistTrackValidator()
        {
            RuleFor(pt => pt.PlaylistId).NotNull();
            RuleFor(pt => pt.TrackId).NotNull();
        }
    }
}