using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.Faq.GetAllFaq;

public class GetAllFaqQueryResponse
{
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
    public List<GetAllFaqResponseDTOs> Faqs { get; set; }
}