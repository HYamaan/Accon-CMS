using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage;

namespace AcconAPI.Application.Features.Queries.ClientPages.HomePage;

public class HomeClientPageQueryResponse
{
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
    public List<SliderDTOs> Sliders { get; set; }
    public GetHomePageWhyChooseUsResponseDTOs WhyChooseUs { get; set; }
    public GetHomePageServiceResponseDTOs Services { get; set; }
    public GetPortfolioResponseDTOs Portfolio { get; set; }
    public GetHomePageTeamMemberResponseDTOs TeamMembers { get; set; }
    public GetHomePageTestimonialResponseDTOs Testimonials { get; set; }
    public GetHomePageFaqResponseDTOs Faqs { get; set; }
    public GetHomePageCounterSectionResponseDTOs CounterSection { get; set; }
    public GetHomePageGalleryResponseDTOs Galleries { get; set; }
    public GetHomePageNewsResponseDTOs News { get; set; }
    public GetHomePagePartnerResponseDTOs Partners { get; set; }

}