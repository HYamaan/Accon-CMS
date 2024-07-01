using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.Designation.GetAllDesignation;

public class GetAllDesignationQueryResponse
{
    public List<GetAllDesignationResponseDTOs> Designation { get; set; }
}