namespace AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage;

public class GetHomePageFaqResponseDTOs
{
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public string? BackgroundImage { get; set; }
    public List<GetFaqResponseDTOs> Faqs { get; set; }

}