using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.News;
using AcconAPI.Domain.Entities.Testimonial;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Dashboard;

public class GetDashboardQueryHandler:IRequestHandler<GetDashboardQueryRequest,ResponseModel<GetDashboardQueryResponse>>
{
    private readonly IGenericRepository<News> _newsRepository;
    private readonly IGenericRepository<NewsCategory> _newsCategoryRepository;
    private readonly IGenericRepository<Domain.Entities.Portfolio.PortfolioCategory> _portfolioCategoryRepository;
    private readonly IGenericRepository<Testimonial> _testimonialRepository;
    private readonly IGenericRepository<Domain.Entities.TeamMember.TeamMember> _teamMemberRepository;
    private readonly IGenericRepository<Domain.Entities.Slider.Slider> _sliderRepository;

    public GetDashboardQueryHandler(IGenericRepository<News> newsRepository, IGenericRepository<NewsCategory> newsCategoryRepository, IGenericRepository<Domain.Entities.Portfolio.PortfolioCategory> portfolioCategoryRepository, IGenericRepository<Testimonial> testimonialRepository, IGenericRepository<Domain.Entities.TeamMember.TeamMember> teamMemberRepository, IGenericRepository<Domain.Entities.Slider.Slider> sliderRepository)
    {
        _newsRepository = newsRepository;
        _newsCategoryRepository = newsCategoryRepository;
        _portfolioCategoryRepository = portfolioCategoryRepository;
        _testimonialRepository = testimonialRepository;
        _teamMemberRepository = teamMemberRepository;
        _sliderRepository = sliderRepository;
    }

    public async Task<ResponseModel<GetDashboardQueryResponse>> Handle(GetDashboardQueryRequest request, CancellationToken cancellationToken)
    {
        var news = await _newsRepository.GetAll().CountAsync();
        var newsCategory = await _newsCategoryRepository.GetAll().CountAsync();
        var portfolioCategory = await _portfolioCategoryRepository.GetAll().CountAsync();
        var testimonial = await _testimonialRepository.GetAll().CountAsync();
        var teamMember = await _teamMemberRepository.GetAll().CountAsync();
        var slider = await _sliderRepository.GetAll().CountAsync();
            
        var response = new GetDashboardQueryResponse
        {
            TotalNewsCount = news,
            TotalNewsCategoryCount = newsCategory,
            TotalPortfolioCount = portfolioCategory,
            TotalTestimonialCount = testimonial,
            TotalTeamMemberCount = teamMember,
            TotalSliderCount = slider
        };

        return ResponseModel<GetDashboardQueryResponse>.Success(response);
    }
}