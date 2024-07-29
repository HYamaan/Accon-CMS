using AcconAPI.Application.Features.Commands.Pages.HomePage;
using AcconAPI.Domain.Entities.Page;
using FluentValidation;

namespace AcconAPI.Application.FluentValidation;

public class PageEntityCommandRequestValidator : AbstractValidator<PageEntity>
{
    public PageEntityCommandRequestValidator()
    {

        RuleFor(x => x.MetaTitle)
            .NotEmpty().WithMessage("MetaTitle is required.")
            .MaximumLength(150).WithMessage("MetaTitle cannot exceed 150 characters.");

        RuleFor(x => x.MetaDescription)
            .NotEmpty().WithMessage("MetaDescription is required.")
            .MaximumLength(160).WithMessage("MetaDescription cannot exceed 160 characters.");

        RuleFor(x => x.MetaKeywords)
            .NotEmpty().WithMessage("MetaKeywords is required.")
            .MaximumLength(140).WithMessage("MetaKeywords cannot exceed 100 characters.");
    }
}
