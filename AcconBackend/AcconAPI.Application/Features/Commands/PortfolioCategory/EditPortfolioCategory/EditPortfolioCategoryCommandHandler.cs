using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using FluentValidation;
using MediatR;

namespace AcconAPI.Application.Features.Commands.PortfolioCategory.EditPortfolioCategory;

public class EditPortfolioCategoryCommandHandler:IRequestHandler<EditPortfolioCategoryCommandRequest, ResponseModel<EditPortfolioCategoryCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Portfolio.PortfolioCategory> _portfolioCategoryRepository;
    private readonly IValidator<EditPortfolioCategoryCommandRequest> _validator;

    public EditPortfolioCategoryCommandHandler(IGenericRepository<Domain.Entities.Portfolio.PortfolioCategory> portfolioCategoryRepository, IValidator<EditPortfolioCategoryCommandRequest> validator)
    {
        _portfolioCategoryRepository = portfolioCategoryRepository;
        _validator = validator;
    }

    public async Task<ResponseModel<EditPortfolioCategoryCommandResponse>> Handle(EditPortfolioCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ResponseModel<EditPortfolioCategoryCommandResponse>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }
        if (request.Id == Guid.Empty)
        {
            return await AddPortfolio(request, cancellationToken);
        }
        return await UpdatePortfolio(request, cancellationToken);
    }

    private async Task<ResponseModel<EditPortfolioCategoryCommandResponse>> AddPortfolio(EditPortfolioCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var portfolioCategory = new Domain.Entities.Portfolio.PortfolioCategory
        {
            Title = request.Title,
            IsActive = request.IsActive
        };
        await _portfolioCategoryRepository.AddAsync(portfolioCategory);
        await _portfolioCategoryRepository.SaveAsync();
        return ResponseModel<EditPortfolioCategoryCommandResponse>.Success();
    }
    private async Task<ResponseModel<EditPortfolioCategoryCommandResponse>> UpdatePortfolio(EditPortfolioCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var portfolioCategory = await _portfolioCategoryRepository.GetByIdAsync(request.Id.ToString());

        if (portfolioCategory == null)
        {
            return ResponseModel<EditPortfolioCategoryCommandResponse>.Fail("Portfolio Category not found");
        }

        if (portfolioCategory.Title != request.Title)
        {
            portfolioCategory.Title = request.Title;
        }

        if (portfolioCategory.IsActive != request.IsActive)
        {
            portfolioCategory.IsActive = request.IsActive;
        }
        _portfolioCategoryRepository.Update(portfolioCategory);
        await _portfolioCategoryRepository.SaveAsync();
        return ResponseModel<EditPortfolioCategoryCommandResponse>.Success();
    }
}