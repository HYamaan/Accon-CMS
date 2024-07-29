namespace AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage;

public class GetHomePageTeamMemberResponseDTOs
{
    public string Title { get; set; }
    public string SubTitle { get; set; }

    public List<GetTeamMemberResponseDTOs> TeamMembers { get; set; }
}