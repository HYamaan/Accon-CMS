using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Designation.GetAllDesignation;

public class GetAllDesignationQueryRequest : IRequest<ResponseModel<GetAllDesignationQueryResponse>>
{
}