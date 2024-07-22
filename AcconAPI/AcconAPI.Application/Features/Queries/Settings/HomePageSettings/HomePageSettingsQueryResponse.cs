using AcconAPI.Application.Models.DTOs.Response.Settings;
using AcconAPI.Domain.Entities.File;

namespace AcconAPI.Application.Features.Queries.Settings.HomePageSettings;

public class HomePageSettingsQueryResponse
{
    public WhyChooseUsResponseModelDTOs WhyChooseUs { get; set; }
    public ServicesResponseModelDTOs Services { get; set; }
    public PortfolioResponseModelDTOs Portfolio { get; set; }
    public TeamResponseModelDTOs Team { get; set; }
    public TestimonialResponseModelDTOs Testimonial { get; set; }
    public FAQResponseModelDTOs FAQ { get; set; }
    public GalleryResponseModelDTOs Gallery { get; set; }
    public RecentPostResponseModelDTOs RecentPost { get; set; }
    public PartnerResponseModelDTOs Partner { get; set; }
    public string CounterBackgroundImage { get; set; }
    public CounterSettingsResponseModelDTOs CounterSettings { get; set; }

}