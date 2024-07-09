using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.Settings.GeneralContent.PhoneIcon;

public class PhoneIconCommandRequest : IRequest<ResponseModel<PhoneIconCommandResponse>>
{
    public IFormFile Photo { get; set; }
}