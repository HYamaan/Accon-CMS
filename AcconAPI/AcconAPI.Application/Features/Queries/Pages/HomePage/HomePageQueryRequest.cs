using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.Pages.HomePage;

public class HomePageQueryRequest : IRequest<ResponseModel<HomePageQueryResponse>>
{
    
}