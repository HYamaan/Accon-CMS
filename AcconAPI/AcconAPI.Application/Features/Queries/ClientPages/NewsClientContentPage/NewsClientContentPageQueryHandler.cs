using AcconAPI.Application.Models.DTOs.Response.ClientPage;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.News;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AcconAPI.Application.Features.Queries.ClientPages.NewsClientContentPage
{
    public class NewsClientContentPageQueryHandler : IRequestHandler<NewsClientContentPageQueryRequest, ResponseModel<NewsClientContentPageQueryResponse>>
    {
        private readonly IGenericRepository<News> _newsRepository;

        public NewsClientContentPageQueryHandler(IGenericRepository<News> newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<ResponseModel<NewsClientContentPageQueryResponse>> Handle(NewsClientContentPageQueryRequest request, CancellationToken cancellationToken)
        {
            var findNews = await _newsRepository.GetWhere(x => x.IsPublished && x.Id == request.Id)
                .Include(x => x.Photo)
                .Include(x => x.Banner)
                .FirstOrDefaultAsync();

            if (findNews == null)
                return ResponseModel<NewsClientContentPageQueryResponse>.Fail("News not found");

            var popularNews = await _newsRepository.GetWhere(x => x.IsPublished)
                .OrderByDescending(x => x.CreatedDate)
                .Take(6)
                .Select(x => new GetClientNewsPopularResponseDTOs()
                {
                    Url = $"view/{x.Id}",
                    Title = x.Title,
                })
                .ToListAsync(cancellationToken);

            var latestNews = popularNews.Take(3).ToList();

            var response = new NewsClientContentPageQueryResponse()
            {
                Url = $"view/{findNews.Id}",
                Title = findNews.Title,
                Description = findNews.ShortContent,
                LongDescription = findNews.Content,
                Photo = findNews.Photo?.Path,
                BackGroundPhoto = findNews.Banner?.Path,
                Date = findNews.CreatedDate.ToString("yyyy-MM-dd"),
                Created = "Admin",
                PopularNews = popularNews,
                LatestNews = latestNews
            };

            return ResponseModel<NewsClientContentPageQueryResponse>.Success(response);
        }
    }
}
