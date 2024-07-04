using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.PortfolioCategory.DeletePortfolioCategory;

public class DeletePortfolioCategoryCommandRequest : IRequest<ResponseModel<DeletePortfolioCategoryCommandResponse>>
{
    public Guid Id { get; set; }
}