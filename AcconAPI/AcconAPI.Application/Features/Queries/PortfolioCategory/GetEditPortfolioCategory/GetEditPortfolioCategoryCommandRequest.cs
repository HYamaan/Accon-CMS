using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Queries.PortfolioCategory.GetEditPortfolioCategory;

public class GetEditPortfolioCategoryCommandRequest : IRequest<ResponseModel<GetEditPortfolioCategoryCommandResponse>>
{
    public Guid Id { get; set; }
}