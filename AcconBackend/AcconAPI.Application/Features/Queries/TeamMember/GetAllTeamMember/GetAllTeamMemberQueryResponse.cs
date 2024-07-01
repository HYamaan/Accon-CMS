using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.TeamMember.GetAllTeamMember;

public class GetAllTeamMemberQueryResponse
{
    public List<GetAllTeamMemberResponseDTOs> TeamMembers { get; set; }
}