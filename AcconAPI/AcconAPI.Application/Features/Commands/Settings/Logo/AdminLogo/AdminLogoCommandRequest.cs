using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.Settings.Logo.AdminLogo;

public class AdminLogoCommandRequest : IRequest<ResponseModel<AdminLogoCommandResponse>>
{
    public IFormFile Photo;
}