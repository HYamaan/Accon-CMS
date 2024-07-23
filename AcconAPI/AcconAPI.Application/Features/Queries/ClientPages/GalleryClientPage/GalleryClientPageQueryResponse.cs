using AcconAPI.Application.Models.DTOs.Response.ClientPage;

namespace AcconAPI.Application.Features.Queries.ClientPages.GalleryPage;

public class GalleryClientPageQueryResponse
{
    public string Heading { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
 public List<GetClientGalleryDTOs> Galleries { get; set; }
}