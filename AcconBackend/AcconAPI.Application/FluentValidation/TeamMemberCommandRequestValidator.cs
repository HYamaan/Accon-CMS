using AcconAPI.Application.Features.Commands.TeamMember.UpdateTeamMember;
using AcconAPI.Application.Services.FluentValidation;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace AcconAPI.Application.FluentValidation;

public class TeamMemberCommandRequestValidator
{
    public class CreateTeamMemberCommandRequestValidator : AbstractValidator<UpdateTeamMemberCommandRequest>, ICreateTeamMemberCommandRequestValidator
    {
        public CreateTeamMemberCommandRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");

            RuleFor(x => x.Designation)
                .NotEmpty().WithMessage("Designation is required.");

            RuleFor(x => x.Image)
                .NotNull().WithMessage("Image is required.");
        }
    }
    public class UpdateTeamMemberCommandRequestValidator : AbstractValidator<UpdateTeamMemberCommandRequest>, IUpdateTeamMemberCommandRequestValidator
    {
        public UpdateTeamMemberCommandRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot be longer than 100 characters.");

            RuleFor(x => x.Designation)
                .NotEmpty().WithMessage("Designation is required.");
        }
    }
}