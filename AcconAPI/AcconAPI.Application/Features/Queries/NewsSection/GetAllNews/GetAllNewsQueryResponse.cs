using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.NewsSection.GetAllNews;

public class GetAllNewsQueryResponse
{
    public List<GetAllNewsResponseDTOs> News { get; set; }
}