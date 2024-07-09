using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Pages.PortfolioPage;

public class PortfolioPageQueryHandler:IRequestHandler<PortfolioPageQueryRequest,ResponseModel<PortfolioPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.PortfolioPage> _portfolioPageRepository;

    public PortfolioPageQueryHandler(IGenericRepository<Domain.Entities.Page.PortfolioPage> portfolioPageRepository)
    {
        _portfolioPageRepository = portfolioPageRepository;
    }

    public async Task<ResponseModel<PortfolioPageQueryResponse>> Handle(PortfolioPageQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _portfolioPageRepository.GetAll().FirstOrDefaultAsync();
        if(result == null)
            return  ResponseModel<PortfolioPageQueryResponse>.Fail("Portfolio Page not defined");

        var response = new PortfolioPageQueryResponse()
        {
            Title = result.Heading,
            MetaTitle = result.MetaTitle,
            MetaDescription = result.MetaDescription,
            MetaKeywords = result.MetaKeywords,
        };
        return ResponseModel<PortfolioPageQueryResponse>.Success(response);
    }
}