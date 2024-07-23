using AcconAPI.Application.Models.DTOs.Response.ClientPage;

namespace AcconAPI.Application.Features.Queries.ClientPages.ServicePage;

public class ServiceClientPageQueryResponse
{
    public string Header { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
    public List<GetClientServiceResponseDTOs> Services { get; set; }
}