using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.Settings.LoginBackground;

public class LoginBackgroundCommandRequest : IRequest<ResponseModel<LoginBackgroundCommandResponse>>
{
    public IFormFile Photo { get; set; }
}