using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.Testimonal.GetAllTestimonal;

public class GetAllTestimonalQueryResponse
{
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
    public List<GetAllTestimonialResponseDTOs> Testimonials { get; set; }
}