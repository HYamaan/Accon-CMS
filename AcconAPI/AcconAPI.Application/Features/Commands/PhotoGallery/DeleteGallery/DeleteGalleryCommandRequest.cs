using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.PhotoGallery.DeleteGallery;

public class DeleteGalleryCommandRequest:IRequest<ResponseModel<DeleteGalleryCommandResponse>>
{
    public Guid Id { get; set; }
}