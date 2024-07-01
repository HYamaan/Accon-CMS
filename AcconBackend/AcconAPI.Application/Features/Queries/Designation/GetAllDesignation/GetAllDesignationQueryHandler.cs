using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Designation.GetAllDesignation;

public class GetAllDesignationQueryHandler:IRequestHandler<GetAllDesignationQueryRequest,ResponseModel<GetAllDesignationQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.TeamMember.Designation> _designationRepository;

    public GetAllDesignationQueryHandler(IGenericRepository<Domain.Entities.TeamMember.Designation> designationRepository)
    {
        _designationRepository = designationRepository;
    }

    public async Task<ResponseModel<GetAllDesignationQueryResponse>> Handle(GetAllDesignationQueryRequest request, CancellationToken cancellationToken)
    {
        var designations = await _designationRepository.GetAll()
            .Select(x => new GetAllDesignationResponseDTOs()
            {
                Id = x.Id,
                Title = x.Title,
            }).ToListAsync(cancellationToken);

        return  ResponseModel<GetAllDesignationQueryResponse>.Success(new GetAllDesignationQueryResponse()
        {
            Designation = designations
        });
    }
}