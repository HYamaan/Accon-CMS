using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Models.DTOs.Response.ClientPage;
using AcconAPI.Application.Models.DTOs.Response.ClientPage.HomePage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using AcconAPI.Domain.Entities.File.WhyChooseUs;
using AcconAPI.Domain.Entities.Gallery;
using AcconAPI.Domain.Entities.Settings;
using AcconAPI.Domain.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.ClientPages.HomePage;

public class HomeClientPageQueryHandler : IRequestHandler<HomeClientPageQueryRequest, ResponseModel<HomeClientPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.HomePage> _homePageEntity;

    private readonly IGenericRepository<Domain.Entities.Settings.HomePageSettings> _homePageSettingsEntity;
    private readonly IGenericRepository<Domain.Entities.Slider.Slider> _sliderEntity;
    private readonly IGenericRepository<Domain.Entities.WhyChooseUs.WhyChoose> _whyChooseRepository;
    private readonly IGenericRepository<Domain.Entities.File.WhyChooseUs.ChooseUsMainPhoto> _whyChooseMainPhotoRepository;
    private readonly IGenericRepository<Domain.Entities.File.WhyChooseUs.ChooseUseBackgroundPhoto> _whyChooseBackgroundPhotoRepository;
    private readonly IGenericRepository<Domain.Entities.Page.ServicePage> _serviceRepository;
    private readonly IGenericRepository<Domain.Entities.TeamMember.TeamMember> _teamMemberRepository;
    private readonly IGenericRepository<Domain.Entities.Page.TestimonialPage> _testimonialPageRepository;
    private readonly IGenericRepository<Domain.Entities.File.Testimonial.TestimonialMainPhoto> _testimonialMainPhotoRepository;

    private readonly IGenericRepository<Domain.Entities.Page.FaqPage> _faqPageRepository;
    private readonly IGenericRepository<Domain.Entities.File.FaqMainPhoto> _faqMainPhotoRepository;

    private readonly IGenericRepository<Domain.Entities.Gallery.Gallery> _galleryRepository;
    private readonly IGenericRepository<Domain.Entities.Page.NewsPage> _newsPageRepository;

    private readonly IGenericRepository<Domain.Entities.Partner.Partner> _partnerRepository;

    public HomeClientPageQueryHandler(IGenericRepository<Domain.Entities.Slider.Slider> sliderEntity, IGenericRepository<ChooseUsMainPhoto> whyChooseMainPhotoRepository, IGenericRepository<ChooseUseBackgroundPhoto> whyChooseBackgroundPhotoRepository, IGenericRepository<Domain.Entities.WhyChooseUs.WhyChoose> whyChooseRepository, IGenericRepository<HomePageSettings> homePageSettingsEntity, IGenericRepository<Domain.Entities.Page.HomePage> homePageEntity, IGenericRepository<Domain.Entities.Page.ServicePage> serviceRepository, IGenericRepository<Domain.Entities.TeamMember.TeamMember> teamMemberRepository, IGenericRepository<Domain.Entities.Page.TestimonialPage> testimonialPageRepository, IGenericRepository<Domain.Entities.File.Testimonial.TestimonialMainPhoto> testimonialMainPhotoRepository, IGenericRepository<FaqMainPhoto> faqMainPhotoRepository, IGenericRepository<Domain.Entities.Page.FaqPage> faqPageRepository, IGenericRepository<Gallery> galleryRepository, IGenericRepository<Domain.Entities.Page.NewsPage> newsPageRepository, IGenericRepository<Domain.Entities.Partner.Partner> partnerRepository)
    {
        _sliderEntity = sliderEntity;
        _whyChooseMainPhotoRepository = whyChooseMainPhotoRepository;
        _whyChooseBackgroundPhotoRepository = whyChooseBackgroundPhotoRepository;
        _whyChooseRepository = whyChooseRepository;
        _homePageSettingsEntity = homePageSettingsEntity;
        _homePageEntity = homePageEntity;
        _serviceRepository = serviceRepository;
        _teamMemberRepository = teamMemberRepository;
        _testimonialPageRepository = testimonialPageRepository;
        _testimonialMainPhotoRepository = testimonialMainPhotoRepository;
        _faqMainPhotoRepository = faqMainPhotoRepository;
        _faqPageRepository = faqPageRepository;
        _galleryRepository = galleryRepository;
        _newsPageRepository = newsPageRepository;
        _partnerRepository = partnerRepository;
    }

    public async Task<ResponseModel<HomeClientPageQueryResponse>> Handle(HomeClientPageQueryRequest request, CancellationToken cancellationToken)
    {
        var homePage = await _homePageEntity.GetWhere(x => x.IsPublished).FirstOrDefaultAsync();
        if (homePage == null)
            return ResponseModel<HomeClientPageQueryResponse>.Fail("Home page not found");

        var response = new HomeClientPageQueryResponse()
        {
            MetaTitle = homePage.MetaTitle,
            MetaDescription = homePage.MetaDescription,
            MetaKeywords = homePage.MetaKeywords,
            Sliders = await GetSliders(),
            WhyChooseUs = await GetWhyChooseUs(),
            Services = await GetServices(),
            Portfolio = await GetPortfolio(),
            TeamMembers = await GetTeamMember(),
            Testimonials = await GetTestimonials(),
            Faqs = await GetFaqs(),
            Galleries = await GetGallery(),
            News = await GetNews(),
           Partners = await GetPartner(),
           CounterSection=await GetCounterSection()


        };
        return ResponseModel<HomeClientPageQueryResponse>.Success(response);
    }
    private async Task<List<SliderDTOs>> GetSliders()
    {
        var sliders = await _sliderEntity.GetAll()
            .Include(s => s.Photo)
            .Select(slider => new SliderDTOs()
            {
                Id = slider.Id,
                Heading = slider.Title,
                Content = slider.Content,
                Button1Text = slider.Button1Text,
                Button1Link = slider.Button1Link,
                Button2Text = slider.Button2Text,
                Button2Link = slider.Button2Link,
                Path = slider.Photo.Path,

            })
            .ToListAsync();
        return sliders;
    }

    private async Task<GetHomePageWhyChooseUsResponseDTOs> GetWhyChooseUs()
    {
        var getHomeWhyChoose = await _homePageSettingsEntity.GetWhere(x => x.SettingId == HomePageEnum.WhyChooseUs && x.Status).FirstOrDefaultAsync();
        if (getHomeWhyChoose == null)
            return null;

        var getAllWhyChoose = await _whyChooseRepository.GetAll()
            .Include(x => x.IconPhoto)
            .Select(ux => new GetAllWhyChooseUsResponseDTOs()
            {
                Id = ux.Id,
                Title = ux.Title,
                Content = ux.Content,
                Photo = ux.IconPhoto.Path
            })
            .ToListAsync();
        var getWhyChooseBackgroundPhoto = await _whyChooseBackgroundPhotoRepository.GetAll().FirstOrDefaultAsync();
        var getWhyChooseMainPhoto = await _whyChooseMainPhotoRepository.GetAll().FirstOrDefaultAsync();

        var response = new GetHomePageWhyChooseUsResponseDTOs()
        {
            Title = getHomeWhyChoose.Title,
            SubTitle = getHomeWhyChoose.SubTitle,
            WhyChooseUsItems = getAllWhyChoose,
            ItemBackground = getWhyChooseBackgroundPhoto?.Path,
            MainPhoto = getWhyChooseMainPhoto?.Path
        };
        return response;
    }

    private async Task<GetHomePageServiceResponseDTOs> GetServices()
    {
        var getHomeService = await _homePageSettingsEntity.GetWhere(x => x.SettingId == HomePageEnum.Service && x.Status).FirstOrDefaultAsync();

        if (getHomeService == null)
            return null;

        var getAllServices = await _serviceRepository.GetAll()
            .Take(6)
            .Include(x => x.ServiceSections)
            .ThenInclude(x => x.Photo)
            .SelectMany(x => x.ServiceSections.Select(y => new ServicesResponseDTOs()
            {
                Id = y.Id,
                Photo = y.Photo.Path,
                Title = y.Title,
                Description = y.ShortContent
            }))
            .ToListAsync();

        var response = new GetHomePageServiceResponseDTOs()
        {
            Title = getHomeService.Title,
            SubTitle = getHomeService.SubTitle,
            Services = getAllServices

        };

        return response;
    }

    private async Task<GetPortfolioResponseDTOs> GetPortfolio()
    {
        var getHomeService = await _homePageSettingsEntity.GetWhere(x => x.SettingId == HomePageEnum.Portfolio && x.Status).FirstOrDefaultAsync();
        if (getHomeService == null)
            return null;

        return new GetPortfolioResponseDTOs()
        {
            IsPublished = true
        };
    }

    private async Task<GetHomePageTeamMemberResponseDTOs> GetTeamMember()
    {
        var getHomeService = await _homePageSettingsEntity.GetWhere(x => x.SettingId == HomePageEnum.Team && x.Status).FirstOrDefaultAsync();
        if (getHomeService == null)
            return null;

        var getAllTeamMembers = await _teamMemberRepository.GetAll()
            .Include(x => x.Photo)
            .Select(x => new GetTeamMemberResponseDTOs()
            {
                Id = x.Id,
                Title = x.Name,
                Designation = x.Designation.Title,
                Photo = x.Photo.Path,
                Facebook = x.Facebook,
                Twitter = x.Twitter,
                LinkedIn = x.LinkedIn,
                Youtube = x.Youtube
            })
            .OrderBy(x => x.Designation)
            .ToListAsync();

        var response = new GetHomePageTeamMemberResponseDTOs()
        {
            Title = getHomeService.Title,
            SubTitle = getHomeService.SubTitle,
            TeamMembers = getAllTeamMembers
        };

        return response;
    }

    private async Task<GetHomePageTestimonialResponseDTOs> GetTestimonials()
    {
        var getHomeService = await _homePageSettingsEntity.GetWhere(x => x.SettingId == HomePageEnum.Testimonial && x.Status).FirstOrDefaultAsync();
        if (getHomeService == null)
            return null;

        var testimonials = await _testimonialPageRepository.GetAll()
            .Include(x => x.Testimonials)
            .ThenInclude(x => x.Photo)
            .SelectMany(ux => ux.Testimonials.Select(t => new GetAllTestimonialResponseDTOs()
            {
                Id = t.Id,
                Name = t.Name,
                Designation = t.Designation,
                Company = t.Company,
                Comment = t.Comment,
                Photo = t.Photo.Path
            })).ToListAsync();

        var getTestimonialMainPhoto = await _testimonialMainPhotoRepository.GetAll().FirstOrDefaultAsync();


        return new GetHomePageTestimonialResponseDTOs()
        {
            Title = getHomeService.Title,
            SubTitle = getHomeService.SubTitle,
            BackgroundImage = getTestimonialMainPhoto != null ? getTestimonialMainPhoto.Path : null,
            Testimonials = testimonials
        };
    }

    private async Task<GetHomePageFaqResponseDTOs> GetFaqs()
    {
        var getHomeService = await _homePageSettingsEntity.GetWhere(x => x.SettingId == HomePageEnum.Faq && x.Status).FirstOrDefaultAsync();
        if (getHomeService == null)
            return null;

        var faqPage = await _faqPageRepository.GetAll()
            .Include(x => x.Faqs)
            .SelectMany(x => x.Faqs.Where(t => t.VisiblePage == VisiblePlace.OnHomeAndSelfPage)
                .Select(t => new GetFaqResponseDTOs()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Content = t.Content
                })).ToListAsync();

        var faqMainPhoto = await _faqMainPhotoRepository.GetAll().FirstOrDefaultAsync();
        var respose = new GetHomePageFaqResponseDTOs()
        {
            Title = getHomeService.Title,
            SubTitle = getHomeService.SubTitle,
            BackgroundImage = faqMainPhoto != null ? faqMainPhoto.Path : null,
            Faqs = faqPage
        };

        return respose;
    }


    private async Task<GetHomePageGalleryResponseDTOs> GetGallery()
    {
        var homePageSettings = await _homePageSettingsEntity.GetWhere(x => x.SettingId == HomePageEnum.Gallery && x.Status).FirstOrDefaultAsync();
        if (homePageSettings == null)
            return null;

        var gallery = await _galleryRepository.GetAll()
            .Include(x => x.GalleryPhoto)
            .Where(x => x.IsVisible == VisiblePlace.OnHome || x.IsVisible == VisiblePlace.OnHomeAndSelfPage)
            .Take(8)
            .Select(t => new GetGalleryResponseDTOs()
            {
                Id = t.Id,
                Title = t.Title,
                Photo = t.GalleryPhoto.Path

            }).ToListAsync();
        var response = new GetHomePageGalleryResponseDTOs()
        {
            Title = homePageSettings.Title,
            SubTitle = homePageSettings.SubTitle,
            Gallery = gallery != null ? gallery : null
        };
        return response;
    }

    private async Task<GetHomePageNewsResponseDTOs> GetNews()
    {
        var homePageSettings = await _homePageSettingsEntity.GetWhere(x => x.SettingId == HomePageEnum.RecentPost && x.Status).FirstOrDefaultAsync();
        if (homePageSettings == null)
            return null;

        var news = await _newsPageRepository.GetWhere(x => x.IsPublished)
            .Include(x => x.News)
            .ThenInclude(x => x.Photo)
            .SelectMany(x => x.News
                .Where(t => t.IsPublished)
                .OrderBy(t => t.CreatedDate)
                .Take(homePageSettings.TotalRecentPosts.Value != null ? homePageSettings.TotalRecentPosts.Value : 0)
                .Select(t => new GetClientNewsPageResponseDTOs()
                {
                    Url = $"view/{t.Id}",
                    Title = t.Title,
                    Description = t.ShortContent,
                    Photo = t.Photo.Path,
                    Date = t.CreatedDate.ToString("yyyy-MM-dd"),
                    Created = "Admin"
                }))
            .ToListAsync();

        var response = new GetHomePageNewsResponseDTOs()
        {
            Title = homePageSettings.Title,
            SubTitle = homePageSettings.SubTitle,
            News = news
        };

        return response;
    }

    private async Task<GetHomePagePartnerResponseDTOs> GetPartner()
    {
        var homePageSettings = await _homePageSettingsEntity.GetWhere(x => x.SettingId == HomePageEnum.Partner && x.Status).FirstOrDefaultAsync();
        if (homePageSettings == null)
            return null;

        var partners = await _partnerRepository.GetAll()
            .Include(x => x.Photo)
            .Select(ux => new GetAllPartnerResponseDTOs()
            {
                Id = ux.Id,
                Name = ux.Name,
                Photo = ux.Photo.Path
            })
            .ToListAsync();

        return new GetHomePagePartnerResponseDTOs()
        {
            Title = homePageSettings.Title,
            SubTitle = homePageSettings.SubTitle,
            Partners = partners
        };
    }

    private async Task<GetHomePageCounterSectionResponseDTOs> GetCounterSection()
    {
        var getCounter = await _homePageSettingsEntity
            .GetWhere(x => x.SettingId == HomePageEnum.CounterSettings && x.Status)
            .FirstOrDefaultAsync();

        if (getCounter == null)
            return null;

        var getBackgroundPhoto = await _homePageSettingsEntity
            .GetWhere(x => x.SettingId == HomePageEnum.CounterBackgroundPhoto)
            .Include(x=>x.CounterBackgroundPhoto)
            .FirstOrDefaultAsync();

        return new GetHomePageCounterSectionResponseDTOs
        {
            BackgroundImage = getBackgroundPhoto.CounterBackgroundPhoto.Path,
            Text1 = getCounter?.Counter1Text,
            Text1Value = getCounter?.Counter1Value,
            Text2 = getCounter?.Counter2Text,
            Text2Value = getCounter?.Counter2Value,
            Text3 = getCounter?.Counter3Text,
            Text3Value = getCounter?.Counter3Value,
            Text4 = getCounter?.Counter4Text,
            Text4Value = getCounter?.Counter4Value
        };
    }
}


