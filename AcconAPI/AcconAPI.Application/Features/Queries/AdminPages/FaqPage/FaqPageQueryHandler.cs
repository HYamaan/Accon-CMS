using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Pages.FaqPage;

public class FaqPageQueryHandler : IRequestHandler<FaqPageQueryRequest, ResponseModel<FaqPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.FaqPage> _faqPageRepository;

    public FaqPageQueryHandler(IGenericRepository<Domain.Entities.Page.FaqPage> faqPageRepository)
    {
        _faqPageRepository = faqPageRepository;
    }

    public async Task<ResponseModel<FaqPageQueryResponse>> Handle(FaqPageQueryRequest request,
        CancellationToken cancellationToken)
    {
        var faqPage = await _faqPageRepository.GetAll().FirstOrDefaultAsync();
        if (faqPage == null)
        {
            return ResponseModel<FaqPageQueryResponse>.Fail("Faq page not found");
        }

        var response = new FaqPageQueryResponse()
        {
            Title = faqPage.Heading,
            MetaTitle = faqPage.MetaTitle,
            MetaDescription = faqPage.MetaDescription,
            MetaKeywords = faqPage.MetaKeywords,
        };
        return ResponseModel<FaqPageQueryResponse>.Success(response);

    }
}