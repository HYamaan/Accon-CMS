namespace AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage.Layout;

public class FooterResponseDTOs
{
    public string? CopyRight { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? WorkingHours { get; set; }
    public string? AboutUs { get; set; }

    public string? AdressIcon { get; set; }
    public string? PhoneIcon { get; set; }
    public string? WorkingHoursIcon { get; set; }

    public List<GetClientNewsPopularResponseDTOs>? LatestNews { get; set; }
}