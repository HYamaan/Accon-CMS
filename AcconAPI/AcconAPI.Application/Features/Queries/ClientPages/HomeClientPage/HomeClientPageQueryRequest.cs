using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.ClientPages.HomePage;

public class HomeClientPageQueryRequest : IRequest<ResponseModel<HomeClientPageQueryResponse>>
{
    
}