using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Designation.GetEditDesignation;

public class GetEditDesignationQueryHandler : IRequestHandler<GetEditDesignationQueryRequest, ResponseModel<GetEditDesignationQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.TeamMember.Designation> _designationRepository;

    public GetEditDesignationQueryHandler(IGenericRepository<Domain.Entities.TeamMember.Designation> designationRepository)
    {
        _designationRepository = designationRepository;
    }

    public async Task<ResponseModel<GetEditDesignationQueryResponse>> Handle(GetEditDesignationQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == null)
            return ResponseModel<GetEditDesignationQueryResponse>.Fail("Id is required");

        var designation = await _designationRepository.GetByIdAsync(request.Id.ToString());

        if (designation == null)
            return ResponseModel<GetEditDesignationQueryResponse>.Fail("Designation not found");

        return ResponseModel<GetEditDesignationQueryResponse>.Success(new GetEditDesignationQueryResponse()
        {
            Id = designation.Id,
            Title = designation.Title,
        });
    }
}