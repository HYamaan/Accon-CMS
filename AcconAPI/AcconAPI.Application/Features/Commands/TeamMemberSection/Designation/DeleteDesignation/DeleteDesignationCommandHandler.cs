using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.TeamMemberSection.Designation.DeleteDesignation;

public class DeleteDesignationCommandHandler : IRequestHandler<DeleteDesignationCommandRequest, ResponseModel<DeleteDesignationCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.TeamMember.Designation> _designationRepository;

    public DeleteDesignationCommandHandler(IGenericRepository<Domain.Entities.TeamMember.Designation> designationRepository)
    {
        _designationRepository = designationRepository;
    }

    public async Task<ResponseModel<DeleteDesignationCommandResponse>> Handle(DeleteDesignationCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return ResponseModel<DeleteDesignationCommandResponse>.Fail("Id is required");
        }
        try
        {
            await _designationRepository.RemoveAsync(request.Id.ToString());
            return ResponseModel<DeleteDesignationCommandResponse>.Success("Designation deleted successfully");
        }
        catch (Exception e)
        {
            return ResponseModel<DeleteDesignationCommandResponse>.Fail(e.Message);
        }


    }
}