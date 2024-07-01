using AcconAPI.Application.Features.Commands.TeamMember.UpdateTeamMember;
using FluentValidation;

namespace AcconAPI.Application.Services.FluentValidation;

public interface IUpdateTeamMemberCommandRequestValidator : IValidator<UpdateTeamMemberCommandRequest> { }