using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Settings.SideFooter;

public class SideFooterQueryHandler:IRequestHandler<SideFooterQueryRequest,ResponseModel<SideFooterQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Settings.GeneralContent> _generalContentRepository;

    public SideFooterQueryHandler(IGenericRepository<Domain.Entities.Settings.GeneralContent> generalContentRepository)
    {
        _generalContentRepository = generalContentRepository;
    }

    public async Task<ResponseModel<SideFooterQueryResponse>> Handle(SideFooterQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _generalContentRepository.GetAll().FirstOrDefaultAsync();
        if (result == null)
        {
            return ResponseModel<SideFooterQueryResponse>.Fail("No Side Footer Found");
        }
        var response = new SideFooterQueryResponse
        {
            PopularPostCount = result.PopularPostCount,
            RecentPostCount = result.RecentPostCount
        };

        return ResponseModel<SideFooterQueryResponse>.Success(response);
    }
}