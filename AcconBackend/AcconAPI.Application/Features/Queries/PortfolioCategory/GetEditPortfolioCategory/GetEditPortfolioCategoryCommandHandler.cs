using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.PortfolioCategory.GetEditPortfolioCategory;

public class GetEditPortfolioCategoryCommandHandler: IRequestHandler<GetEditPortfolioCategoryCommandRequest, ResponseModel<GetEditPortfolioCategoryCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Portfolio.PortfolioCategory> _portfolioCategoryRepository;

    public GetEditPortfolioCategoryCommandHandler(IGenericRepository<Domain.Entities.Portfolio.PortfolioCategory> portfolioCategoryRepository)
    {
        _portfolioCategoryRepository = portfolioCategoryRepository;
    }

    public async Task<ResponseModel<GetEditPortfolioCategoryCommandResponse>> Handle(GetEditPortfolioCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return ResponseModel<GetEditPortfolioCategoryCommandResponse>.Fail("Id is required");
        }
        var portfolioCategory = await _portfolioCategoryRepository.GetByIdAsync(request.Id.ToString());
        if (portfolioCategory == null)
        {
            return ResponseModel<GetEditPortfolioCategoryCommandResponse>.Fail("Portfolio Category not found");
        }
        var response = new GetEditPortfolioCategoryCommandResponse()
        {
            Id = portfolioCategory.Id,
            Title = portfolioCategory.Title,
            IsActive = portfolioCategory.IsActive
        };
        return ResponseModel<GetEditPortfolioCategoryCommandResponse>.Success(response);
    }
}