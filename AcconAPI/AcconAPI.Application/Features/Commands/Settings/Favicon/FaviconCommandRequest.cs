using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.Settings.Favicon;

public class FaviconCommandRequest : IRequest<ResponseModel<FaviconCommandResponse>>
{
    public IFormFile Photo { get; set; }
}