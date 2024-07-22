using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Dashboard;

public class GetDashboardQueryRequest : IRequest<ResponseModel<GetDashboardQueryResponse>>
{
    
}