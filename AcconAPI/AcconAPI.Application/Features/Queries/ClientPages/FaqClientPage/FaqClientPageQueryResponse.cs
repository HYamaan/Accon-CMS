using AcconAPI.Application.Models.DTOs.Response.ClientPage;

namespace AcconAPI.Application.Features.Queries.ClientPages.FaqPage;

public class FaqClientPageQueryResponse
{

    public string Heading { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
    public string MainPhoto { get; set; }
public List<GetClientFaqPageResponseDTOs> Faqs { get; set; }

}