using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Pages.PrivacyPage;

public class PrivacyPageQueryHandler:IRequestHandler<PrivacyPageQueryRequest,ResponseModel<PrivacyPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.PrivacyPage> _privacyPageRepository;

    public PrivacyPageQueryHandler(IGenericRepository<Domain.Entities.Page.PrivacyPage> privacyPageRepository)
    {
        _privacyPageRepository = privacyPageRepository;
    }

    public async Task<ResponseModel<PrivacyPageQueryResponse>> Handle(PrivacyPageQueryRequest request, CancellationToken cancellationToken)
    {
       var result = await _privacyPageRepository.GetAll().FirstOrDefaultAsync();

       if (result == null)
       {
           return  ResponseModel<PrivacyPageQueryResponse>.Fail( "Privacy page not found");
       }

       var response = new PrivacyPageQueryResponse()
       {
           Title = result.Heading,
           Content = result.Content,
           MetaTitle = result.MetaTitle,
           MetaDescription = result.MetaDescription,
           MetaKeywords = result.MetaKeywords
       };
       return ResponseModel<PrivacyPageQueryResponse>.Success(response);
    }
}