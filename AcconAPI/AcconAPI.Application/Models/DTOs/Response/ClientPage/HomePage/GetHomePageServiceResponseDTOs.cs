namespace AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage;

public class GetHomePageServiceResponseDTOs
{
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public List<ServicesResponseDTOs> Services { get; set; }
}