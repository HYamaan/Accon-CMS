namespace AcconAPI.Application.Models.DTOs.Request;

public class UpdateSocialMediaRequestDTOs
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string? Content { get; set; }
}