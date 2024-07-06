using AcconAPI.Application.Features.Commands.Menu;
using AcconAPI.Application.Services.FluentValidation;
using FluentValidation;

namespace AcconAPI.Application.FluentValidation;

public class UpdateMenuCommandRequestValidator : AbstractValidator<UpdateMenuCommandRequest>, IUpdateMenuCommandRequestValidator
{
    public UpdateMenuCommandRequestValidator()
    {
        RuleForEach(x => x.pages).ChildRules(page =>
        {
            page.RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required for update.");
            page.RuleFor(x => x.IsPublished).NotNull().WithMessage("IsPublished status is required.");
        });
    }
}