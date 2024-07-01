using AcconAPI.Application.Features.Commands.Designation.UpdateDesignation;
using AcconAPI.Domain.Entities.TeamMember;
using FluentValidation;

namespace AcconAPI.Application.FluentValidation;

public class DesignationValidator : AbstractValidator<UpdateDesignationCommandRequest>
{
    public DesignationValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");
    }
}