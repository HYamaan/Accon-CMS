using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Models.DTOs.Response.ClientPage;
using AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage.Layout;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.Settings;
using AcconAPI.Domain.Entities.News;
using AcconAPI.Domain.Entities.Page;
using AcconAPI.Domain.Entities.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.ClientPages.LayoutClientPage;

public class LayoutClientPageQueryHandler:IRequestHandler<LayoutClientPageQueryRequest, ResponseModel<LayoutClientPageQueryResponse>>
{
    private readonly IGenericRepository<GeneralContent> _generalContentRepository;
    public readonly IGenericRepository<Domain.Entities.File.Settings.FooterAdressIcon> _footerAdressIconRepository;
    public readonly IGenericRepository<Domain.Entities.File.Settings.FooterPhoneIcon> _footerPhoneIconRepository;
    public readonly IGenericRepository<Domain.Entities.File.Settings.FooterWorkingIcon> _FooterWorkingIconRepository;
    public readonly IGenericRepository<Domain.Entities.File.Settings.WebSiteLogo> _websiteLogo;
    public readonly IGenericRepository<News> _news;

    public readonly IGenericRepository<Domain.Entities.Page.PageEntity> _pageEntity;
    public LayoutClientPageQueryHandler(IGenericRepository<GeneralContent> generalContentRepository, IGenericRepository<PageEntity> pageEntity, IGenericRepository<FooterAdressIcon> footerAdressIconRepository, IGenericRepository<FooterPhoneIcon> footerPhoneIconRepository, IGenericRepository<FooterWorkingIcon> footerWorkingIconRepository, IGenericRepository<WebSiteLogo> websiteLogo, IGenericRepository<News> news)
    {
        _generalContentRepository = generalContentRepository;
        _pageEntity = pageEntity;
        _footerAdressIconRepository = footerAdressIconRepository;
        _footerPhoneIconRepository = footerPhoneIconRepository;
        _FooterWorkingIconRepository = footerWorkingIconRepository;
        _websiteLogo = websiteLogo;
        _news = news;
    }

    public async Task<ResponseModel<LayoutClientPageQueryResponse>> Handle(LayoutClientPageQueryRequest request, CancellationToken cancellationToken)
    {

        var getGeneralContent = await _generalContentRepository.GetAll().FirstOrDefaultAsync();
        var getFooterAdressIcon = await _footerAdressIconRepository.GetAll().OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync();
        var getFooterPhoneIcon = await _footerPhoneIconRepository.GetAll().OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync();
        var getFooterWorkingIcon = await _FooterWorkingIconRepository.GetAll().OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync();
        var getWebsiteLogo = await _websiteLogo.GetAll().OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync();
        var getNews = new List<GetClientNewsPopularResponseDTOs>();
        if (getGeneralContent != null)
        {
             getNews = await _news.GetAll().OrderByDescending(x => x.CreatedDate).Take(getGeneralContent.RecentPostCount.Value).Select(x => new GetClientNewsPopularResponseDTOs()
                {
                    Url = $"view/{x.Id}",
                    Title = x.Title,
                })
                .ToListAsync(cancellationToken);
        }

        var response = new LayoutClientPageQueryResponse
        {
            Header = new HeaderResponseDTOs
            {
                Logo = getWebsiteLogo?.Path,
                TopBarPhone = getGeneralContent?.TopBarPhone,
                TopBarEmail = getGeneralContent?.TopBarEmail,
                Navigations = new List<NavigationResponseDTOs>
                {
                    new NavigationResponseDTOs
                    {
                        Title = "Home",
                        Url = "/"
                    },
                    new NavigationResponseDTOs
                    {
                        Title = "About",
                        Url = "/about"
                    },
                    new NavigationResponseDTOs
                    {
                        Title = "FAQ",
                        Url = "/faq"
                    },
                    new NavigationResponseDTOs
                    {
                        Title = "Services",
                        Url = "/services"
                    },
                    new NavigationResponseDTOs
                    {
                        Title = "Gallery",
                        Url = "/gallery"
                    },
                    new NavigationResponseDTOs
                    {
                        Title = "Testimonials",
                        Url = "/testimonials"
                    },
                    new NavigationResponseDTOs
                    {
                        Title = "Contact",
                        Url = "/contact"
                    }
                }
            },
            Footer = new FooterResponseDTOs
            {
                CopyRight= getGeneralContent?.FooterCopyRight,
                AboutUs = getGeneralContent?.FooterAboutUs,
                Address = getGeneralContent?.FooterAdress,
                Phone = getGeneralContent?.FooterPhone,
                WorkingHours = getGeneralContent?.FooterWorkingHours,
                AdressIcon = getFooterAdressIcon?.Path,
                PhoneIcon = getFooterPhoneIcon?.Path,
                WorkingHoursIcon = getFooterWorkingIcon?.Path,
                LatestNews = getNews
            }
        };

        return ResponseModel<LayoutClientPageQueryResponse>.Success(response);

    }
}