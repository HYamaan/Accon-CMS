using AcconAPI.Application.Models.DTOs.Response.ClientPage;

namespace AcconAPI.Application.Features.Queries.ClientPages.ServiceClientContentPage;

public class ServiceClientContentPageQueryResponse
{
    public string Header { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }

    public string Photo { get; set; }
    public string Content { get; set; }
    public List<GetClientLastServicesResponseDTOs> LastServices { get; set; }
}