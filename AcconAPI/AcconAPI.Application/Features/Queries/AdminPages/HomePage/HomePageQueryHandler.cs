using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Pages.HomePage;

public class HomePageQueryHandler:IRequestHandler<HomePageQueryRequest, ResponseModel<HomePageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.HomePage> _homePageRepository;

    public HomePageQueryHandler(IGenericRepository<Domain.Entities.Page.HomePage> homePageRepository)
    {
        _homePageRepository = homePageRepository;
    }

    public async Task<ResponseModel<HomePageQueryResponse>> Handle(HomePageQueryRequest request, CancellationToken cancellationToken)
    {
        var homePage = await _homePageRepository.GetAll().FirstAsync();
        var response = new HomePageQueryResponse
        {
            MetaTitle = homePage.MetaTitle,
            MetaKeywords = homePage.MetaKeywords,
            MetaDescription = homePage.MetaDescription,
        };
        return ResponseModel<HomePageQueryResponse>.Success(response);
    }
}