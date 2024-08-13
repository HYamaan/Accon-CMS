namespace AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage.Layout;

public class HeaderResponseDTOs
{
    public string Logo { get; set; }
    public string? TopBarEmail { get; set; }
    public string? TopBarPhone { get; set; }

    public List<SocialMediaResponseDTOs>? SocialMedias { get; set; }
    public List<NavigationResponseDTOs> Navigations { get; set; }
}