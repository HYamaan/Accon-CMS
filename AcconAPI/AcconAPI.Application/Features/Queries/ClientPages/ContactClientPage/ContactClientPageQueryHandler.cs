using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.ClientPages.ContactPage;

public class ContactClientPageQueryHandler:IRequestHandler<ContactClientPageQueryRequest,ResponseModel<ContactClientPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.ContactPage> _contactPageRepository;
    private readonly IGenericRepository<Domain.Entities.Settings.GeneralContent> _generalContentRepository;

    public ContactClientPageQueryHandler(IGenericRepository<Domain.Entities.Page.ContactPage> contactPageRepository, IGenericRepository<GeneralContent> generalContentRepository)
    {
        _contactPageRepository = contactPageRepository;
        _generalContentRepository = generalContentRepository;
    }

    public async Task<ResponseModel<ContactClientPageQueryResponse>> Handle(ContactClientPageQueryRequest request, CancellationToken cancellationToken)
    {
        var contactPage = await _contactPageRepository.GetWhere(x => x.IsPublished)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (contactPage == null)
        {
            return ResponseModel<ContactClientPageQueryResponse>.Fail("Contact page not found");
        }
        var generalContent = await _generalContentRepository.GetAll()
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);


        var response = new ContactClientPageQueryResponse()
        {
            Header = contactPage.Heading,
            MetaTitle = contactPage.MetaTitle,
            MetaDescription = contactPage.MetaDescription,
            MetaKeywords = contactPage.MetaKeywords,
            IFramSrc = generalContent?.ContactMap
        };

        return ResponseModel<ContactClientPageQueryResponse>.Success(response);
    }
}