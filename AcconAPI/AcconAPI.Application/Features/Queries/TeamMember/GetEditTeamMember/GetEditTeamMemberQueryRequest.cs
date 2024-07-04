using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.TeamMember.GetEditTeamMember;

public class GetEditTeamMemberQueryRequest : IRequest<ResponseModel<GetEditTeamMemberQueryResponse>>
{
    public Guid Id { get; set; }
}