using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.PhotoGallery.GetAllPhotoGallery;

public class GetAllPhotoGalleryQueryResponse
{
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
    public List<GetAllGalleryResponseDTOs> gallery { get; set; }
}