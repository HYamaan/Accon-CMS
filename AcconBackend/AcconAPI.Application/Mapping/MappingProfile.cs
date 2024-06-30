using AcconAPI.Application.Features.Commands.Pages.ContactPage;
using AcconAPI.Application.Features.Commands.Pages.FaqPage;
using AcconAPI.Application.Features.Commands.Pages.GalleryPage;
using AcconAPI.Application.Features.Commands.Pages.HomePage;
using AcconAPI.Application.Features.Commands.Pages.NewsPage;
using AcconAPI.Application.Features.Commands.Pages.PortfolioPage;
using AcconAPI.Application.Features.Commands.Pages.PrivacyPage;
using AcconAPI.Application.Features.Commands.Pages.ServicePage;
using AcconAPI.Application.Features.Commands.Pages.TermsPage;
using AcconAPI.Application.Features.Commands.Pages.TestimonialPage;
using AcconAPI.Application.Models;
using AcconAPI.Domain.Entities.Page;
using AutoMapper;

namespace AcconAPI.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<HomePageCommandRequest, PageEntity>().ReverseMap();
        CreateMap<GalleryPageCommandRequest, PageEntity>().ReverseMap();
        CreateMap<FaqPageCommandRequest, PageEntity>().ReverseMap();
        CreateMap<ServicePageCommandRequest, PageEntity>().ReverseMap();
        CreateMap<PortfolioPageCommandRequest,PageEntity>().ReverseMap();
        CreateMap<TestimonialPageCommandRequest,PageEntity>().ReverseMap();
        CreateMap<NewsPageCommandRequest,PageEntity>().ReverseMap();
        CreateMap<ContactPageCommandRequest, PageEntity>().ReverseMap();

        CreateMap<TermsPageCommandRequest,PageEntityWithContentMap>().ReverseMap();
        CreateMap<PrivacyPageCommandRequest,PageEntityWithContentMap>().ReverseMap();

    }
}
