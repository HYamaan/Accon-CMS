using AcconAPI.Application.Models.DTOs.Response;

namespace AcconAPI.Application.Features.Queries.PortfolioCategory.GetAllPortfolioCategory;

public class GetAllPortfolioCategoryQueryResponse
{
    public List<GetAllPortfolioCategoryResponseDTOs> PortfolioCategories { get; set; }
}