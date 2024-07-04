using AcconAPI.Domain.Enum;

namespace AcconAPI.Application.Models.DTOs.Response;

public class GetAllGalleryResponseDTOs
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Photo { get; set; }
    public VisiblePlace VisiblePlace { get; set; }
}