using AcconAPI.Application.Models.DTOs.Response.ClientPage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.ClientPages.NewsPage;

public class NewsClientPageHandler:IRequestHandler<NewsClientPageRequest,ResponseModel<NewsClientPageResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.NewsPage> _newsPageRepository;

    public NewsClientPageHandler(IGenericRepository<Domain.Entities.Page.NewsPage> newsPageRepository)
    {
        _newsPageRepository = newsPageRepository;
    }

    public async Task<ResponseModel<NewsClientPageResponse>> Handle(NewsClientPageRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var newsPage = await _newsPageRepository.GetWhere(x => x.IsPublished)
                .Include(x => x.News)
                .ThenInclude(x => x.Photo)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (newsPage == null)
                return ResponseModel<NewsClientPageResponse>.Fail("News page not found");

            var news = newsPage.News.Select(x=> new GetClientNewsPageResponseDTOs()
            {
                Url =$"view/{x.Id}",
                Title = x.Title,
                Description = x.ShortContent,
                Photo = x.Photo?.Path,
                Date = x.CreatedDate.ToString("yyyy-MM-dd"),
                Created = "Admin"
            }).ToList();

            var response = new NewsClientPageResponse()
            {
                Header = newsPage.Heading,
                MetaTitle = newsPage.MetaTitle,
                MetaDescription = newsPage.MetaDescription,
                MetaKeywords = newsPage.MetaKeywords,
                News = news
            };
            return ResponseModel<NewsClientPageResponse>.Success(response);
        }
        catch (Exception e)
        {
            return ResponseModel<NewsClientPageResponse>.Fail(e.Message);
        }
    }
}