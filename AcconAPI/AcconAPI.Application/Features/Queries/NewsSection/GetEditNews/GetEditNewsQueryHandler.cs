using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.News;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.NewsSection.GetEditNews;

public class GetEditNewsQueryHandler:IRequestHandler<GetEditNewsQueryRequest,ResponseModel<GetEditNewsQueryResponse>>
{
    private readonly IGenericRepository<News> _newsRepository;

    public GetEditNewsQueryHandler(IGenericRepository<News> newsRepository)
    {
        _newsRepository = newsRepository;
    }

    public async Task<ResponseModel<GetEditNewsQueryResponse>> Handle(GetEditNewsQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.Id == Guid.Empty)
            {
                return ResponseModel<GetEditNewsQueryResponse>.Fail("Id is required");
            }
            var findNew = await _newsRepository.GetWhere(x => x.Id == request.Id)
                .Include(x => x.Photo)
                .Include(x => x.Banner)
                .Include(x => x.NewsCategory)
                .Select(x => new GetEditNewsQueryResponse()
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortContent = x.ShortContent,
                    Content = x.Content,
                    PublishDate = x.PublishDate,
                    CategoryId = x.NewsCategory.Id,
                    CategoryName = x.NewsCategory.Title,
                     IsPublished = x.IsPublished,
                    CommentShow = x.CommentShow,
                    BannerPhoto = x.Banner.Path,
                    FeaturePhoto = x.Photo.Path,
                    MetaTitle = x.MetaTitle,
                    MetaDescription = x.MetaDescription,
                    MetaKeyword = x.MetaKeywords
                })
                .FirstOrDefaultAsync(cancellationToken);
            if (findNew == null)
            {
                return ResponseModel<GetEditNewsQueryResponse>.Fail("News not found");
            }

            return ResponseModel<GetEditNewsQueryResponse>.Success(findNew);
        }
        catch (Exception e)
        {
          return ResponseModel<GetEditNewsQueryResponse>.Fail(e.Message);
        }
    }
}