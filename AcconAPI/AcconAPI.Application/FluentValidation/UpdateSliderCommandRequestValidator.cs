using AcconAPI.Application.Features.Commands.Slider.UpdateSlider;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.FluentValidation;



public class UpdateSliderCommandRequestValidator : AbstractValidator<UpdatedSliderCommandRequest>
{
    public UpdateSliderCommandRequestValidator()
    {
        RuleFor(x => x.Photo)
            .NotNull().WithMessage("Photo is required.");

        RuleFor(x => x.Heading)
            .NotEmpty().WithMessage("Heading is required.")
            .MaximumLength(100).WithMessage("Heading cannot be longer than 100 characters.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.");

        RuleFor(x => x.Button1Text)
            .MaximumLength(50).WithMessage("Button1Text cannot be longer than 50 characters.");

        RuleFor(x => x.Button1Link)
            .MaximumLength(200).WithMessage("Button1Link cannot be longer than 200 characters.");

        RuleFor(x => x.Button2Text)
            .MaximumLength(50).WithMessage("Button2Text cannot be longer than 50 characters.");

        RuleFor(x => x.Button2Link)
            .MaximumLength(200).WithMessage("Button2Link cannot be longer than 200 characters.");
    }
}
