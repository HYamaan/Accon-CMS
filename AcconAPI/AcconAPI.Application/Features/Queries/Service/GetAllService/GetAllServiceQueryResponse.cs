using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.Service.GetAllService;

public class GetAllServiceQueryResponse
{

    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public string? MetaKeywords { get; set; }
    public List<ServiceDTOs>? Services { get; set; }
}