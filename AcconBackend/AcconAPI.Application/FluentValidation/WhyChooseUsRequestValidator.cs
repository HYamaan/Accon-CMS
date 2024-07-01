using AcconAPI.Application.Features.Commands.WhyChooseUs.UpdateWhyChooseUs;
using AcconAPI.Application.Services.FluentValidation;
using FluentValidation;

namespace AcconAPI.Application.FluentValidation;

public class WhyChooseUsRequestValidator
{
    public class CreateWhyChooseUsCommandRequestValidator : AbstractValidator<UpdateWhyChooseUsCommandRequest>, ICreateWhyChooseUsCommandRequestValidator
    {
        public CreateWhyChooseUsCommandRequestValidator()
        {
            RuleFor(x => x.Heading)
                .NotEmpty().WithMessage("Heading is required.")
                .MaximumLength(100).WithMessage("Heading cannot be longer than 100 characters.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(500).WithMessage("Content cannot be longer than 500 characters.");

            RuleFor(x => x.Photo)
                .NotNull().WithMessage("Photo is required.");
        }
    }
    public class UpdateWhyChooseUsCommandRequestValidator : AbstractValidator<UpdateWhyChooseUsCommandRequest>, IUpdateWhyChooseUsCommandRequestValidator
    {
        public UpdateWhyChooseUsCommandRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.Heading)
                .NotEmpty().WithMessage("Heading is required.")
                .MaximumLength(100).WithMessage("Heading cannot be longer than 100 characters.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(500).WithMessage("Content cannot be longer than 500 characters.");
        }
    }
}