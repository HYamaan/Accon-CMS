namespace AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage;

public class GetHomePageGalleryResponseDTOs
{
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public List<GetGalleryResponseDTOs>? Gallery { get; set; }
}