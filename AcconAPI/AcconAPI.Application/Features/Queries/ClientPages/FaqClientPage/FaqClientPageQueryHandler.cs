using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Models.DTOs.Response.ClientPage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using AcconAPI.Domain.Entities.Settings;
using AcconAPI.Domain.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.ClientPages.FaqPage;

public class FaqClientPageQueryHandler:IRequestHandler<FaqClientPageQueryRequest,ResponseModel<FaqClientPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.FaqPage> _faqPageRepository;
    private readonly IGenericRepository<FaqMainPhoto> _faqMainPhotoRepository;
    private readonly IGenericRepository<Domain.Entities.Settings.HomePageSettings> _homePageSettingsEntity;
    public FaqClientPageQueryHandler(IGenericRepository<Domain.Entities.Page.FaqPage> faqPageRepository, IGenericRepository<FaqMainPhoto> faqMainPhotoRepository, IGenericRepository<HomePageSettings> homePageSettingsEntity)
    {
        _faqPageRepository = faqPageRepository;
        _faqMainPhotoRepository = faqMainPhotoRepository;
        _homePageSettingsEntity = homePageSettingsEntity;
    }

    public async Task<ResponseModel<FaqClientPageQueryResponse>> Handle(FaqClientPageQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var getHomeService = await _homePageSettingsEntity.GetWhere(x => x.SettingId == HomePageEnum.Faq).FirstOrDefaultAsync();
            if (getHomeService == null)
                return null;



            var faqPage = await _faqPageRepository.GetAll()
                .Include(x => x.Faqs)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if(faqPage == null)
                return ResponseModel<FaqClientPageQueryResponse>.Fail("Faq page not found");

            var mainPhoto = await _faqMainPhotoRepository.GetAll()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            var faqs = faqPage.Faqs
                .Where(x => x.VisiblePage == VisiblePlace.OnSelfPage || x.VisiblePage == VisiblePlace.OnHomeAndSelfPage)
                .Select(faq => new GetClientFaqPageResponseDTOs
                {
                    Id = faq.Id,
                    Title = faq.Title,
                    Content = faq.Content
                })
                .ToList();

            var response = new FaqClientPageQueryResponse()
            {
                Heading = faqPage.Heading,
                MetaTitle = faqPage.MetaTitle,
                MetaDescription = faqPage.MetaDescription,
                MetaKeywords = faqPage.MetaKeywords,
                MainPhoto = mainPhoto?.Path,
                Title = getHomeService.Title,
                SubTitle = getHomeService.SubTitle,
                Faqs = faqs
            };

            return ResponseModel<FaqClientPageQueryResponse>.Success(response);
        }
        catch (Exception e)
        {
            return ResponseModel<FaqClientPageQueryResponse>.Fail(e.Message);
        }



    }
}