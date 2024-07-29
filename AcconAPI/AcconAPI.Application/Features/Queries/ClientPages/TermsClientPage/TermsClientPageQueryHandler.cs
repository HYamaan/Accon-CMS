using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.ClientPages.TermsPage;

public class TermsClientPageQueryHandler : IRequestHandler<TermsClientPageQueryRequest, ResponseModel<TermsClientPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.TermsPage> _termsPage;

    public TermsClientPageQueryHandler(IGenericRepository<Domain.Entities.Page.TermsPage> termsPage)
    {
        _termsPage = termsPage;
    }

    public async Task<ResponseModel<TermsClientPageQueryResponse>> Handle(TermsClientPageQueryRequest request, CancellationToken cancellationToken)
    {
        var getTermsPage = await _termsPage.GetAll().FirstOrDefaultAsync();
        if (getTermsPage == null)
            return ResponseModel<TermsClientPageQueryResponse>.Fail("Terms Page not found");
        var response = new TermsClientPageQueryResponse()
        {
            Header = getTermsPage.Heading,
            MetaTitle = getTermsPage.MetaTitle,
            MetaDescription = getTermsPage.MetaDescription,
            MetaKeywords = getTermsPage.MetaKeywords,
            Content = getTermsPage.Terms
        };
        return ResponseModel<TermsClientPageQueryResponse>.Success(response);
    }
}