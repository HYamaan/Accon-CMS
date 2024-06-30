using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Menu;

public class GetMenuQueryRequest:IRequest<ResponseModel<GetMenuQueryResponse>>
{
    
}