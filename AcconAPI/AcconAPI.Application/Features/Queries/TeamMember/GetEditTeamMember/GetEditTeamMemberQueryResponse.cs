namespace AcconAPI.Application.Features.Queries.TeamMember.GetEditTeamMember;

public class GetEditTeamMemberQueryResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid DesignationId { get; set; }
    public string Designation { get; set; }
    public string Photo { get; set; }
    public string? Facebook { get; set; }
    public string? Twitter { get; set; }
    public string? LinkedIn { get; set; }
    public string? Youtube { get; set; }
}