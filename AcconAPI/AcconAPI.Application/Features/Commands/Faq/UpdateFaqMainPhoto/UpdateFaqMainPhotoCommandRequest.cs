using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.Faq.UpdateFaqMainPhoto;

public class UpdateFaqMainPhotoCommandRequest:IRequest<ResponseModel<UpdateFaqMainPhotoCommandResponse>>
{
    public IFormFile Photo { get; set; }
}