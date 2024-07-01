using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;

namespace AcconAPI.Application.Features.Commands.PortfolioCategory.DeletePortfolioCategory;

public class DeletePortfolioCategoryCommandHandler:IRequestHandler<DeletePortfolioCategoryCommandRequest,ResponseModel<DeletePortfolioCategoryCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Portfolio.PortfolioCategory> _portfolioCategoryRepository;

    public DeletePortfolioCategoryCommandHandler(IGenericRepository<Domain.Entities.Portfolio.PortfolioCategory> portfolioCategoryRepository)
    {
        _portfolioCategoryRepository = portfolioCategoryRepository;
    }

    public async Task<ResponseModel<DeletePortfolioCategoryCommandResponse>> Handle(DeletePortfolioCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.Id == Guid.Empty)
            {
                return ResponseModel<DeletePortfolioCategoryCommandResponse>.Fail("Id is required");
            }

            await _portfolioCategoryRepository.RemoveAsync(request.Id.ToString());
            await _portfolioCategoryRepository.SaveAsync();
            return ResponseModel<DeletePortfolioCategoryCommandResponse>.Success();
        }
        catch (Exception e)
        {
           return ResponseModel<DeletePortfolioCategoryCommandResponse>.Fail(e.Message);
        }
    }
}