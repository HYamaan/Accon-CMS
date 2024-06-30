using AcconAPI.Domain.Enum;

namespace AcconAPI.Application.Models.DTOs.Response;

public class GetAllFaqResponseDTOs
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public VisiblePlace VisiblePage { get; set; }
}