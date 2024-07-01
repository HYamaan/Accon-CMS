namespace AcconAPI.Application.Models.DTOs.Response;

public class GetAllNewsResponseDTOs
{
    public Guid Id { get; set; }
    public string Photo { get; set; }
    public string Banner { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
}