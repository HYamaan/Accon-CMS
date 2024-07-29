using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.ClientPages.PrivacyPage;

public class PrivacyClientPageQueryHandler:IRequestHandler<PrivacyClientPageQueryRequest,ResponseModel<PrivacyClientPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.PrivacyPage> _privacyPage;

    public PrivacyClientPageQueryHandler(IGenericRepository<Domain.Entities.Page.PrivacyPage> privacyPage)
    {
        _privacyPage = privacyPage;
    }

    public async Task<ResponseModel<PrivacyClientPageQueryResponse>> Handle(PrivacyClientPageQueryRequest request, CancellationToken cancellationToken)
    {
        var getPrivacyPage = await _privacyPage.GetAll().FirstOrDefaultAsync();
        if(getPrivacyPage == null)
            return ResponseModel<PrivacyClientPageQueryResponse>.Fail("Privacy Page not found");

        var response = new PrivacyClientPageQueryResponse()
        {
            Header = getPrivacyPage.Heading,
            MetaTitle = getPrivacyPage.MetaTitle,
            MetaDescription = getPrivacyPage.MetaDescription,
            MetaKeywords = getPrivacyPage.MetaKeywords,
            Content = getPrivacyPage.Content
        };
        return ResponseModel<PrivacyClientPageQueryResponse>.Success(response);
    }
}