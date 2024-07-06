using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.TeamMember.GetAllTeamMember;

public class GetAllTeamMemberQueryHandler:IRequestHandler<GetAllTeamMemberQueryRequest, ResponseModel<GetAllTeamMemberQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.TeamMember.TeamMember> _teamMemberRepository;

    public GetAllTeamMemberQueryHandler(IGenericRepository<Domain.Entities.TeamMember.TeamMember> teamMemberRepository)
    {
        _teamMemberRepository = teamMemberRepository;
    }

    public async Task<ResponseModel<GetAllTeamMemberQueryResponse>> Handle(GetAllTeamMemberQueryRequest request, CancellationToken cancellationToken)
    {
       var teamMembers = await _teamMemberRepository.GetAll()
           .Include(x => x.Photo)
           .Select(x => new GetAllTeamMemberResponseDTOs()
           {
               Id = x.Id,
               Title=x.Name,
               Designation = x.Designation.Title,
               Photo = x.Photo.Path,
           })
           .OrderBy(x => x.Title)
           .ToListAsync(cancellationToken);

       var response = new GetAllTeamMemberQueryResponse()
       {
           TeamMembers = teamMembers
       };

       return  ResponseModel<GetAllTeamMemberQueryResponse>.Success(response);
    }
}