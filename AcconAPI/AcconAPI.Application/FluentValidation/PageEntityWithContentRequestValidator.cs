using AcconAPI.Application.Models;
using FluentValidation;

namespace AcconAPI.Application.FluentValidation;

public class PageEntityWithContentRequestValidator: AbstractValidator<PageEntityWithContentMap>
{
    public PageEntityWithContentRequestValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.")
            .MaximumLength(5000).WithMessage("Content cannot exceed 5000 characters.");
        RuleFor(x => x.Heading)
            .NotEmpty().WithMessage("Heading is required.")
            .MaximumLength(60).WithMessage("Heading cannot exceed 60 characters.");

        RuleFor(x => x.MetaTitle)
            .NotEmpty().WithMessage("MetaTitle is required.")
            .MaximumLength(60).WithMessage("MetaTitle cannot exceed 60 characters.");

        RuleFor(x => x.MetaDescription)
            .NotEmpty().WithMessage("MetaDescription is required.")
            .MaximumLength(160).WithMessage("MetaDescription cannot exceed 160 characters.");

        RuleFor(x => x.MetaKeywords)
            .NotEmpty().WithMessage("MetaKeywords is required.")
            .MaximumLength(100).WithMessage("MetaKeywords cannot exceed 100 characters.");
    }
}