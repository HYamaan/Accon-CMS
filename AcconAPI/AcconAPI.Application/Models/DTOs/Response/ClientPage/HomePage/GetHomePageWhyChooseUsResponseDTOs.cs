namespace AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage;

public class GetHomePageWhyChooseUsResponseDTOs
{
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public string? MainPhoto { get; set; }
    public string? ItemBackground { get; set; }

    public List<GetAllWhyChooseUsResponseDTOs>? WhyChooseUsItems { get; set; }

}