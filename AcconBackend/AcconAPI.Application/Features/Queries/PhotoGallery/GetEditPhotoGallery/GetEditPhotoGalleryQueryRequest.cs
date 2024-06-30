using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.PhotoGallery.GetEditPhotoGallery;

public class GetEditPhotoGalleryQueryRequest : IRequest<ResponseModel<GetEditPhotoGalleryQueryResponse>>
{
    public Guid Id { get; set; }
}