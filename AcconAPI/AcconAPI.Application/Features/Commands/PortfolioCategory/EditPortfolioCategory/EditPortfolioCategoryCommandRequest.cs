using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.PortfolioCategory.EditPortfolioCategory;

public class EditPortfolioCategoryCommandRequest : IRequest<ResponseModel<EditPortfolioCategoryCommandResponse>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsActive { get; set; }
}