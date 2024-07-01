namespace AcconAPI.Application.Models.DTOs.Response;

public class GetAllTestimonialResponseDTOs
{
    public Guid Id { get; set; }
    public string Photo { get; set; }
    public string Name { get; set; }
    public string Designation { get; set; }
    public string Company { get; set; }
    public string Comment { get; set; }
}