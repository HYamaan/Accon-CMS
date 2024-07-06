using AcconAPI.Application.Models.DTOs.Response;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Menu;

public class GetMenuQueryHandler:IRequestHandler<GetMenuQueryRequest, ResponseModel<GetMenuQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.PageEntity> _pageEntity;

    public GetMenuQueryHandler(IGenericRepository<PageEntity> pageEntity)
    {
        _pageEntity = pageEntity;
    }

    public async Task<ResponseModel<GetMenuQueryResponse>> Handle(GetMenuQueryRequest request, CancellationToken cancellationToken)
    {

        var pages = await _pageEntity.GetAll(false)
            .Select(page => new MenuPageDTOs
            {
                Id =page.Id,
                Page = EF.Property<string>(page, "Page"),
                IsPublished = page.IsPublished,
            })
            .OrderBy(x=>x.Page)
            .ToListAsync(cancellationToken);
        var response = new GetMenuQueryResponse
        {
            Pages = pages
        };

        return ResponseModel<GetMenuQueryResponse>.Success(response);
    }
}