using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.TeamMember.GetEditTeamMember;

public class GetEditTeamMemberQueryHandler:IRequestHandler<GetEditTeamMemberQueryRequest, ResponseModel<GetEditTeamMemberQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.TeamMember.TeamMember> _teamMemberRepository;

    public GetEditTeamMemberQueryHandler(IGenericRepository<Domain.Entities.TeamMember.TeamMember> teamMemberRepository)
    {
        _teamMemberRepository = teamMemberRepository;
    }

    public async Task<ResponseModel<GetEditTeamMemberQueryResponse>> Handle(GetEditTeamMemberQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return ResponseModel<GetEditTeamMemberQueryResponse>.Fail("Id is required");
        }

        var teamMember = await _teamMemberRepository.GetWhere(x=>x.Id == request.Id)
            .Include(x => x.Photo)
            .FirstOrDefaultAsync(cancellationToken);
        

        if (teamMember == null)
        {
            return ResponseModel<GetEditTeamMemberQueryResponse>.Fail("Team member not found");
        }
        var response = new GetEditTeamMemberQueryResponse
        {
            Id = teamMember.Id,
            Title = teamMember.Name,
            Designation = teamMember.DesignationId,
            Photo = teamMember.Photo.Path,
            Facebook = teamMember.Facebook,
            Twitter = teamMember.Twitter,
            LinkedIn = teamMember.LinkedIn,
            Youtube = teamMember.Youtube
        };

        return ResponseModel<GetEditTeamMemberQueryResponse>.Success(response);
    }
}