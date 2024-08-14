using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.AdminPages.LoginPage;

public class LoginPageQueryRequest : IRequest<ResponseModel<LoginPageQueryResponse>>
{
    
}