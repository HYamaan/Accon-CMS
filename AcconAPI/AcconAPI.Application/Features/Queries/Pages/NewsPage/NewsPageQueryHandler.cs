using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Pages.NewsPage;

public class NewsPageQueryHandler:IRequestHandler<NewsPageQueryRequest,ResponseModel<NewsPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.NewsPage> _newsPageRepository;

    public NewsPageQueryHandler(IGenericRepository<Domain.Entities.Page.NewsPage> newsPageRepository)
    {
        _newsPageRepository = newsPageRepository;
    }

    public async Task<ResponseModel<NewsPageQueryResponse>> Handle(NewsPageQueryRequest request, CancellationToken cancellationToken)
    {
       var result = await _newsPageRepository.GetAll().FirstOrDefaultAsync();
       if (result == null)
       {
          return ResponseModel<NewsPageQueryResponse>.Fail("News page not found");
       }

       var reponse = new NewsPageQueryResponse()
       {
           Title = result.Heading,
           MetaTitle = result.MetaTitle,
           MetaDescription = result.MetaDescription,
           MetaKeywords = result.MetaKeywords,
       };
       return ResponseModel<NewsPageQueryResponse>.Success(reponse);
    }
}