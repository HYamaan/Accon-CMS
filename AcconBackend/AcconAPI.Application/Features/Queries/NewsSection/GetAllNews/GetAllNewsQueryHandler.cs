using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.News;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.NewsSection.GetAllNews;

public class GetAllNewsQueryHandler:IRequestHandler<GetAllNewsQueryRequest, ResponseModel<GetAllNewsQueryResponse>>
{
    private readonly IGenericRepository<News> _newsRepository;

    public GetAllNewsQueryHandler(IGenericRepository<News> newsRepository)
    {
        _newsRepository = newsRepository;
    }

    public async Task<ResponseModel<GetAllNewsQueryResponse>> Handle(GetAllNewsQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var news = await _newsRepository.GetAll()
                .Include(n => n.Photo)
                .Include(n => n.Banner)
                .Include(n => n.NewsCategory)
                .Select(x => new GetAllNewsResponseDTOs()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Category = x.NewsCategory.Title,
                    Banner = x.Banner.Path,
                    Photo = x.Photo.Path,
                })
                .ToListAsync(cancellationToken);

            var response = new GetAllNewsQueryResponse()
            {
                News = news
            };
            return ResponseModel<GetAllNewsQueryResponse>.Success(response);
        }
        catch (Exception e)
        {
            return ResponseModel<GetAllNewsQueryResponse>.Fail(e.Message);
        }
    }
}