using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Pages.ContactPage;

public class ContactPageQueryHandler : IRequestHandler<ContactPageQueryRequest, ResponseModel<ContactPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.ContactPage> _contactPageRepository;

    public ContactPageQueryHandler(IGenericRepository<Domain.Entities.Page.ContactPage> contactPageRepository)
    {
        _contactPageRepository = contactPageRepository;
    }

    public async Task<ResponseModel<ContactPageQueryResponse>> Handle(ContactPageQueryRequest request, CancellationToken cancellationToken)
    {
        var contactPage = await _contactPageRepository.GetAll().FirstOrDefaultAsync();
        if (contactPage == null)
        {
            return ResponseModel<ContactPageQueryResponse>.Fail("Contact Page not found");
        }

        var response = new ContactPageQueryResponse()
        {
            Title = contactPage.Heading,
            MetaTitle = contactPage.MetaTitle,
            MetaDescription = contactPage.MetaDescription,
            MetaKeywords = contactPage.MetaKeywords,
        };
        return ResponseModel<ContactPageQueryResponse>.Success(response);

    }
}