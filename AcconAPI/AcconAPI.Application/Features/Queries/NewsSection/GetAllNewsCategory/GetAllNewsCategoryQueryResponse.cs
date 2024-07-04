using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.NewsSection.GetAllNewsCategory;

public class GetAllNewsCategoryQueryResponse
{
    public List<GetAllNewsCategoryResponseDTOs> NewsCategories { get; set; }
}