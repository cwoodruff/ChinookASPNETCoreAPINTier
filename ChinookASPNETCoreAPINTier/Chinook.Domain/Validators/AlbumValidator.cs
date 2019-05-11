using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class AlbumValidator : AbstractValidator<AlbumApiModel>
    {
        public AlbumValidator()
        {
            RuleFor(a => a.Title).NotEmpty();
            RuleFor(a => a.ArtistId).NotNull();
        }
    }
}