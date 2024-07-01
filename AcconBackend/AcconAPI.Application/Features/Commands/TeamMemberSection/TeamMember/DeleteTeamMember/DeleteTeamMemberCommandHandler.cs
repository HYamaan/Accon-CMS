using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.TeamMemberSection.TeamMember.DeleteTeamMember;

public class DeleteTeamMemberCommandHandler : IRequestHandler<DeleteTeamMemberCommandRequest, ResponseModel<DeleteTeamMemberCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.TeamMember.TeamMember> _teamMemberRepository;

    public DeleteTeamMemberCommandHandler(IGenericRepository<Domain.Entities.TeamMember.TeamMember> teamMemberRepository)
    {
        _teamMemberRepository = teamMemberRepository;
    }

    public async Task<ResponseModel<DeleteTeamMemberCommandResponse>> Handle(DeleteTeamMemberCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return ResponseModel<DeleteTeamMemberCommandResponse>.Fail("Id is required");
        }

        try
        {
            await _teamMemberRepository.RemoveAsync(request.Id.ToString());
            await _teamMemberRepository.SaveAsync();

            return ResponseModel<DeleteTeamMemberCommandResponse>.Success();
        }
        catch (Exception e)
        {
            return ResponseModel<DeleteTeamMemberCommandResponse>.Fail(e.Message);
        }

    }
}