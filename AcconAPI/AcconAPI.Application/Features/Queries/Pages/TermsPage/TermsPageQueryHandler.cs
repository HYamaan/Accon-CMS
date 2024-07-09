using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Pages.TermsPage;

public class TermsPageQueryHandler : IRequestHandler<TermsPageQueryRequest, ResponseModel<TermsPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.TermsPage> _termsPageRepository;

    public TermsPageQueryHandler(IGenericRepository<Domain.Entities.Page.TermsPage> termsPageRepository)
    {
        _termsPageRepository = termsPageRepository;
    }

    public async Task<ResponseModel<TermsPageQueryResponse>> Handle(TermsPageQueryRequest request,
        CancellationToken cancellationToken)
    {
        var termsPage = await _termsPageRepository.GetAll().FirstOrDefaultAsync();
        if (termsPage == null)
        {
            return ResponseModel<TermsPageQueryResponse>.Fail("Terms page not found");
        }

        var response = new TermsPageQueryResponse()
        {
            Title = termsPage.Heading,
            Content = termsPage.Terms,
            MetaTitle = termsPage.MetaTitle,
            MetaDescription = termsPage.MetaDescription,
            MetaKeywords = termsPage.MetaKeywords
        };
        return ResponseModel<TermsPageQueryResponse>.Success(response);
    }
}