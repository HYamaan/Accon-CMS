using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.WhyChooseUs.UpdateWhyChooseUsMainPhoto;

public class UpdateWhyChooseUsMainPhotoCommandRequest : IRequest<ResponseModel<UpdateWhyChooseUsMainPhotoCommandResponse>>
{
    public IFormFile Photo { get; set; }
}