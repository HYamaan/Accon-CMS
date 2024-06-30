using AcconAPI.Application.Features.Commands.PhotoGallery.UpdateGallery;
using AcconAPI.Application.Services.FluentValidation;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace AcconAPI.Application.FluentValidation;

public class GaleryPhotoCommandRequestValidator
{
    public class CreatePhotoGalleryValidator : AbstractValidator<UpdateGalleryCommandRequest>, ICreatePhotoGalleryValidator
    {
        public CreatePhotoGalleryValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");

            RuleFor(x => x.VisiblePlace)
                .IsInEnum().WithMessage("VisiblePlace is required and must be a valid enum value.");

            RuleFor(x => x.Photo)
                .NotNull().WithMessage("Photo is required.");
        }

    }

    public class UpdatePhotoGalleryValidator : AbstractValidator<UpdateGalleryCommandRequest>, IUpdatePhotoGalleryValidator
    {
        public UpdatePhotoGalleryValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");

            RuleFor(x => x.VisiblePlace)
                .IsInEnum().WithMessage("VisiblePlace is required and must be a valid enum value.");
        }
    }
}