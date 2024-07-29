namespace AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage;

public class GetHomePageTestimonialResponseDTOs
{
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public string? BackgroundImage { get; set; }
    public List<GetAllTestimonialResponseDTOs> Testimonials { get; set; }
}