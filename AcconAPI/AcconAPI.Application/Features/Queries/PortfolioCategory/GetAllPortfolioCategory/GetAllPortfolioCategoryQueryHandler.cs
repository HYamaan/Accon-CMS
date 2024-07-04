using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.PortfolioCategory.GetAllPortfolioCategory;

public class GetAllPortfolioCategoryQueryHandler:IRequestHandler<GetAllPortfolioCategoryQueryRequest,ResponseModel<GetAllPortfolioCategoryQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Portfolio.PortfolioCategory> _portfolioCategoryRepository;

    public GetAllPortfolioCategoryQueryHandler(IGenericRepository<Domain.Entities.Portfolio.PortfolioCategory> portfolioCategoryRepository)
    {
        _portfolioCategoryRepository = portfolioCategoryRepository;
    }

    public async Task<ResponseModel<GetAllPortfolioCategoryQueryResponse>> Handle(GetAllPortfolioCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _portfolioCategoryRepository.GetAll()
            .Select(x=> new GetAllPortfolioCategoryResponseDTOs()
            {
                Id = x.Id,
                Title = x.Title,
                IsActive = x.IsActive
            }).ToListAsync(cancellationToken);

        var response = new GetAllPortfolioCategoryQueryResponse()
        {
            PortfolioCategories = result
        };
        return ResponseModel<GetAllPortfolioCategoryQueryResponse>.Success(response);

    }
}