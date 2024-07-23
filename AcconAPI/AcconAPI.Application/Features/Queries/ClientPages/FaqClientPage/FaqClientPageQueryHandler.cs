using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Models.DTOs.Response.ClientPage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using AcconAPI.Domain.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.ClientPages.FaqPage;

public class FaqClientPageQueryHandler:IRequestHandler<FaqClientPageQueryRequest,ResponseModel<FaqClientPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.FaqPage> _faqPageRepository;
    private readonly IGenericRepository<FaqMainPhoto> _faqMainPhotoRepository;

    public FaqClientPageQueryHandler(IGenericRepository<Domain.Entities.Page.FaqPage> faqPageRepository, IGenericRepository<FaqMainPhoto> faqMainPhotoRepository)
    {
        _faqPageRepository = faqPageRepository;
        _faqMainPhotoRepository = faqMainPhotoRepository;
    }

    public async Task<ResponseModel<FaqClientPageQueryResponse>> Handle(FaqClientPageQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
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