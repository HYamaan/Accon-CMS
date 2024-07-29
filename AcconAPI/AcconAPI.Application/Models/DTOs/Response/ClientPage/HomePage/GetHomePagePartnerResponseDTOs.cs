namespace AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage;

public class GetHomePagePartnerResponseDTOs
{
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public List<GetAllPartnerResponseDTOs> Partners { get; set; }
}