using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.TeamMember.DeleteTeamMember;

public class DeleteTeamMemberCommandRequest : IRequest<ResponseModel<DeleteTeamMemberCommandResponse>>
{
    public Guid Id { get; set; }
}