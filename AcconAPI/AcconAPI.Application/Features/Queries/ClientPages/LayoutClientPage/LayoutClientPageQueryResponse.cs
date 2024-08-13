using AcconAPI.Application.Models.DTOs.Response.ClientPage;
using AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage.Layout;

namespace AcconAPI.Application.Features.Queries.ClientPages.LayoutClientPage;

public class LayoutClientPageQueryResponse
{
    public HeaderResponseDTOs Header { get; set; }
    public FooterResponseDTOs Footer { get; set; }
}