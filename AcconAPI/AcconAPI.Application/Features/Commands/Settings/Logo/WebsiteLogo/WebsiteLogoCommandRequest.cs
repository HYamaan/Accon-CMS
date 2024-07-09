using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.Settings.Logo.WebsiteLogo;

public class WebsiteLogoCommandRequest : IRequest<ResponseModel<WebsiteLogoCommandResponse>>
{
    public IFormFile Photo { get; set; }
}