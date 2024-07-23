using AcconAPI.Application.Models.DTOs.Response.ClientPage;

namespace AcconAPI.Application.Features.Queries.ClientPages.TestimonialPage;

public class TestimonialClientPageQueryResponse
{
    public string Header { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
    public List<GetClientTestimonialPageResponseDTOs> Testimonials { get; set; }
}