using AcconAPI.Application.Features.Commands.TestimonialSection.Testimonial.UpdateTestimonial;
using AcconAPI.Application.Services.FluentValidation;
using FluentValidation;

namespace AcconAPI.Application.FluentValidation;

public class TestimonialCommandRequestValidator
{
    public class CreateTestimonialCommandRequestValidator : AbstractValidator<UpdateTestimonialCommandRequest>, ICreateTestimonialCommandRequestValidator
    {
        public CreateTestimonialCommandRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot be longer than 100 characters.");

            RuleFor(x => x.Designation)
                .NotEmpty().WithMessage("Designation is required.")
                .MaximumLength(100).WithMessage("Designation cannot be longer than 100 characters.");

            RuleFor(x => x.Company)
                .NotEmpty().WithMessage("Company is required.")
                .MaximumLength(100).WithMessage("Company cannot be longer than 100 characters.");

            RuleFor(x => x.Photo)
                .NotNull().WithMessage("Photo is required.");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Comment is required.")
                .MaximumLength(500).WithMessage("Comment cannot be longer than 500 characters.");
        }
    }
    public class UpdateTestimonialCommandRequestValidator : AbstractValidator<UpdateTestimonialCommandRequest>, IUpdateTestimonialCommandRequestValidator
    {
        public UpdateTestimonialCommandRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot be longer than 100 characters.");

            RuleFor(x => x.Designation)
                .NotEmpty().WithMessage("Designation is required.")
                .MaximumLength(100).WithMessage("Designation cannot be longer than 100 characters.");

            RuleFor(x => x.Company)
                .NotEmpty().WithMessage("Company is required.")
                .MaximumLength(100).WithMessage("Company cannot be longer than 100 characters.");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Comment is required.")
                .MaximumLength(500).WithMessage("Comment cannot be longer than 500 characters.");
        }
    }
}