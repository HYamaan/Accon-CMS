using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Page;

public class GetPageQueryRequest:IRequest<ResponseModel<GetPageQueryResponse>>
{
    
}