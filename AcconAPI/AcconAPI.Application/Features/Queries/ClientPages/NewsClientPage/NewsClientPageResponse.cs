using AcconAPI.Application.Models.DTOs.Response.ClientPage;

namespace AcconAPI.Application.Features.Queries.ClientPages.NewsPage;

public class NewsClientPageResponse
{
    public string Header { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }

    public List<GetClientNewsPageResponseDTOs> News { get; set; }
}