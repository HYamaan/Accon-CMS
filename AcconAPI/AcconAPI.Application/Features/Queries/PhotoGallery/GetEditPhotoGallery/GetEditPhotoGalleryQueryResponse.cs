using AcconAPI.Domain.Enum;

namespace AcconAPI.Application.Features.Queries.PhotoGallery.GetEditPhotoGallery;

public class GetEditPhotoGalleryQueryResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Photo { get; set; }
    public VisiblePlace VisiblePlace { get; set; }
}