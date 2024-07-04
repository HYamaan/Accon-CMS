using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.Menu;

public class GetMenuQueryResponse
{
    public List<MenuPageDTOs> Pages { get; set; }
}