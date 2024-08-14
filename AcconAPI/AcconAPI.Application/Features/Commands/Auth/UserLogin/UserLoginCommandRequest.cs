using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Auth.UserLogin;

public class UserLoginCommandRequest : IRequest<ResponseModel<UserLoginCommandResponse>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}