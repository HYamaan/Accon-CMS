using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.TeamMemberSection.TeamMember.UpdateTeamMember;

public class UpdateTeamMemberCommandRequest : IRequest<ResponseModel<UpdateTeamMemberCommandResponse>>
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public Guid Designation { get; set; }
    public IFormFile? Image { get; set; }
    public string? Facebook { get; set; }
    public string? Twitter { get; set; }
    public string? LinkedIn { get; set; }
    public string? Youtube { get; set; }


}