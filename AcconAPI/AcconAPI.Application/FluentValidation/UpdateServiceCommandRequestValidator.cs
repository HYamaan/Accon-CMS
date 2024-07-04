using AcconAPI.Application.Features.Commands.Service;
using AcconAPI.Application.Services.FluentValidation;
using FluentValidation;

namespace AcconAPI.Application.FluentValidation;

public class UpdateServiceCommandRequestValidator : AbstractValidator<UpdateServiceCommandRequest>, IUpdateServiceCommandRequestValidator
{
    public UpdateServiceCommandRequestValidator()
    {
        RuleFor(x => x.Heading)
            .NotEmpty().WithMessage("Heading is required.")
            .MaximumLength(100).WithMessage("Heading cannot be longer than 100 characters.");

        RuleFor(x => x.ShortContent)
            .NotEmpty().WithMessage("ShortContent is required.")
            .MaximumLength(200).WithMessage("ShortContent cannot be longer than 200 characters.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.")
            .MaximumLength(500).WithMessage("Content cannot be longer than 500 characters.");

        RuleFor(x => x.Photo)
            .NotNull().WithMessage("Photo is required.");

        RuleFor(x => x.Banner)
            .NotNull().WithMessage("Banner is required.");
    }
}

public class UpdateServiceContentCommandRequestValidator : AbstractValidator<UpdateServiceCommandRequest>, IUpdateServiceContentCommandRequestValidator
{
    public UpdateServiceContentCommandRequestValidator()
    {
        RuleFor(x => x.Heading)
            .NotEmpty().WithMessage("Heading is required.")
            .MaximumLength(100).WithMessage("Heading cannot be longer than 100 characters.");

        RuleFor(x => x.ShortContent)
            .NotEmpty().WithMessage("ShortContent is required.")
            .MaximumLength(200).WithMessage("ShortContent cannot be longer than 200 characters.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.")
            .MaximumLength(500).WithMessage("Content cannot be longer than 500 characters.");
    }
}