namespace AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage;

public class GetTeamMemberResponseDTOs
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Designation { get; set; }
    public string Photo { get; set; }

    public string? Facebook { get; set; }
    public string? Twitter { get; set; }
    public string? LinkedIn { get; set; }
    public string? Youtube { get; set; }
}