using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Service.GetAllService;

public class GetAllServiceQueryRequest:IRequest<ResponseModel<GetAllServiceQueryResponse>>
{
}