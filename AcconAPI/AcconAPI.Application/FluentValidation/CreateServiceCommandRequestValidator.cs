using AcconAPI.Application.Features.Commands.Service.UpdateService;
using FluentValidation;

namespace AcconAPI.Application.FluentValidation;

public class CreateServiceCommandRequestValidator: AbstractValidator<UpdateServiceCommandRequest>
{
    public CreateServiceCommandRequestValidator()
    {
        RuleFor(x => x.Heading)
            .NotEmpty().WithMessage("Heading is required.")
            .MaximumLength(100).WithMessage("Heading cannot be longer than 100 characters.");

        RuleFor(x => x.ShortContent)
            .NotEmpty().WithMessage("ShortContent is required.")
            .MaximumLength(200).WithMessage("ShortContent cannot be longer than 200 characters.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.")
            .MinimumLength(10).WithMessage("Content cannot be longer than 500 characters.");

    }
}