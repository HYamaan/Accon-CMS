using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.News;
using MediatR;

namespace AcconAPI.Application.Features.Queries.NewsSection.GetEditNewsCategory;

public class GetEditNewsCategoryQueryHandler:IRequestHandler<GetEditNewsCategoryQueryRequest,ResponseModel<GetEditNewsCategoryQueryResponse>>
{
    private readonly IGenericRepository<NewsCategory> _newsCategoryRepository;

    public GetEditNewsCategoryQueryHandler(IGenericRepository<NewsCategory> newsCategoryRepository)
    {
        _newsCategoryRepository = newsCategoryRepository;
    }

    public async Task<ResponseModel<GetEditNewsCategoryQueryResponse>> Handle(GetEditNewsCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return ResponseModel<GetEditNewsCategoryQueryResponse>.Fail("Id is required");
        }
        var newsCategory = await _newsCategoryRepository.GetByIdAsync(request.Id.ToString());
        if (newsCategory == null)
        {
            return ResponseModel<GetEditNewsCategoryQueryResponse>.Fail("News Category not found");
        }

        var response = new GetEditNewsCategoryQueryResponse()
        {
            Id = newsCategory.Id,
            Title = newsCategory.Title,
        };
        return ResponseModel<GetEditNewsCategoryQueryResponse>.Success(response);

    }
}