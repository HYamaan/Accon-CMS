using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Service.GetEditService;

public class GetEditServiceQueryRequest:IRequest<ResponseModel<GetEditServiceQueryResponse>>
{
    public Guid Id { get; set; }
}