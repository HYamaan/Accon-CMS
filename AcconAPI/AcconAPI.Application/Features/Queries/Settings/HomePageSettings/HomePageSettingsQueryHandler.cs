using AcconAPI.Application.Models.DTOs.Response.Settings;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Settings.HomePageSettings;

public class HomePageSettingsQueryHandler:IRequestHandler<HomePageSettingsQueryRequest, ResponseModel<HomePageSettingsQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Settings.HomePageSettings> _homePageRepository;

    public HomePageSettingsQueryHandler(IGenericRepository<Domain.Entities.Settings.HomePageSettings> homePageRepository)
    {
        _homePageRepository = homePageRepository;
    }


    public async Task<ResponseModel<HomePageSettingsQueryResponse>> Handle(HomePageSettingsQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _homePageRepository.GetAll()
            .Include(x=>x.CounterBackgroundPhoto)
            .ToListAsync();
        if (result == null || !result.Any())
            return ResponseModel<HomePageSettingsQueryResponse>.Fail("No data found");

        var response = new HomePageSettingsQueryResponse();

        foreach (var item in result)
        {
            switch (item.SettingId)
            {
                case HomePageEnum.WhyChooseUs:
                    response.WhyChooseUs = new WhyChooseUsResponseModelDTOs
                    {
                        Title = item.Title,
                        SubTitle = item.SubTitle,
                        Status = item.Status
                    };
                    break;
                case HomePageEnum.Service:
                    response.Services = new ServicesResponseModelDTOs
                    {
                        Title = item.Title,
                        SubTitle = item.SubTitle,
                        Status = item.Status
                    };
                    break;
                case HomePageEnum.Portfolio:
                    response.Portfolio = new PortfolioResponseModelDTOs
                    {
                        Title = item.Title,
                        SubTitle = item.SubTitle,
                        Status = item.Status
                    };
                    break;
                case HomePageEnum.Team:
                    response.Team = new TeamResponseModelDTOs
                    {
                        Title = item.Title,
                        SubTitle = item.SubTitle,
                        Status = item.Status
                    };
                    break;
                case HomePageEnum.Testimonial:
                    response.Testimonial = new TestimonialResponseModelDTOs
                    {
                        Title = item.Title,
                        SubTitle = item.SubTitle,
                        Status = item.Status
                    };
                    break;
                case HomePageEnum.Faq:
                    response.FAQ = new FAQResponseModelDTOs
                    {
                        Title = item.Title,
                        SubTitle = item.SubTitle,
                        Status = item.Status
                    };
                    break;
                case HomePageEnum.Gallery:
                    response.Gallery = new GalleryResponseModelDTOs
                    {
                        Title = item.Title,
                        SubTitle = item.SubTitle,
                         Status = item.Status
                    };
                    break;
                case HomePageEnum.RecentPost:
                    response.RecentPost = new RecentPostResponseModelDTOs
                    {
                        Title = item.Title,
                        SubTitle = item.SubTitle,
                        Status = item.Status,
                        RecentPostCount=item.TotalRecentPosts ??0
                    };
                    break;
                case HomePageEnum.Partner:
                    response.Partner = new PartnerResponseModelDTOs
                    {
                        Title = item.Title,
                        SubTitle = item.SubTitle,
                        Status = item.Status
                    };
                    break;
                case HomePageEnum.CounterBackgroundPhoto:
                    response.CounterBackgroundImage = item.CounterBackgroundPhoto?.Path;
                    break;
                case HomePageEnum.CounterSettings:
                    response.CounterSettings = new CounterSettingsResponseModelDTOs
                    {
                        Counter1Text = item.Counter1Text,
                        Counter1Value = item.Counter1Value,
                        Counter2Text = item.Counter2Text,
                        Counter2Value = item.Counter2Value,
                        Counter3Text = item.Counter3Text,
                        Counter3Value = item.Counter3Value,
                        Counter4Text = item.Counter4Text,
                        Counter4Value = item.Counter4Value,
                        Status = item.Status
                    };
                    break;
                default:
                    break;
            }
        }

        return ResponseModel<HomePageSettingsQueryResponse>.Success(response);
    }

}