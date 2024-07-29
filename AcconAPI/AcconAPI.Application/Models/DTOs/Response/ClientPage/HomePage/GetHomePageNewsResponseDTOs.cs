namespace AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage;

public class GetHomePageNewsResponseDTOs
{
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public List<GetClientNewsPageResponseDTOs>? News { get; set; }
}