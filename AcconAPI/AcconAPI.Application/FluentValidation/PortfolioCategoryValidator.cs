using AcconAPI.Application.Features.Commands.PortfolioCategory.EditPortfolioCategory;
using AcconAPI.Domain.Entities.Portfolio;
using FluentValidation;

namespace AcconAPI.Application.FluentValidation;

public class PortfolioCategoryValidator : AbstractValidator<EditPortfolioCategoryCommandRequest>
{
    public PortfolioCategoryValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");

        RuleFor(x => x.IsActive)
            .NotNull().WithMessage("IsActive status is required.");
    }
}