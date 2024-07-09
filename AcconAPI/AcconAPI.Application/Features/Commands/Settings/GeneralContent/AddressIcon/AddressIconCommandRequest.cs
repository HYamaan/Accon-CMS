using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.Settings.GeneralContent.AddressIcon;

public class AddressIconCommandRequest : IRequest<ResponseModel<AddressIconCommandResponse>>
{
    public IFormFile Photo { get; set; }
}