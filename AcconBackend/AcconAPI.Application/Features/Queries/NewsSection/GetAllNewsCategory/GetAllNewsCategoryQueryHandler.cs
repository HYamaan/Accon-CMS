using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.News;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.NewsSection.GetAllNewsCategory;

public class GetAllNewsCategoryQueryHandler:IRequestHandler<GetAllNewsCategoryQueryRequest,ResponseModel<GetAllNewsCategoryQueryResponse>>
{
    private readonly IGenericRepository<NewsCategory> _newsCategoryRepository;

    public GetAllNewsCategoryQueryHandler(IGenericRepository<NewsCategory> newsCategoryRepository)
    {
        _newsCategoryRepository = newsCategoryRepository;
    }

    public async Task<ResponseModel<GetAllNewsCategoryQueryResponse>> Handle(GetAllNewsCategoryQueryRequest request, CancellationToken cancellationToken)
    {
       var result = await _newsCategoryRepository.GetAll()
           .Select(x=> new GetAllNewsCategoryResponseDTOs()
           {
               Id = x.Id,
               Title = x.Title,
           })
           .ToListAsync(cancellationToken);
       var response = new GetAllNewsCategoryQueryResponse()
       {
           NewsCategories = result
       };
    
       return ResponseModel<GetAllNewsCategoryQueryResponse>.Success(response);
    }
}