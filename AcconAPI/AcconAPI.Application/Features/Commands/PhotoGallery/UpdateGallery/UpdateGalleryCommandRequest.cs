using AcconAPI.Domain.Common;
using AcconAPI.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Features.Commands.PhotoGallery.UpdateGallery;

public class UpdateGalleryCommandRequest: IRequest<ResponseModel<UpdateGalleryCommandResponse>>
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public IFormFile? Photo { get; set; }
    public VisiblePlace VisiblePlace { get; set; }
}