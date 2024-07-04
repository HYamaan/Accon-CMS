using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.Page;
using MediatR;

namespace AcconAPI.Application.Features.Commands.Menu;

public class UpdateMenuCommandHandler:IRequestHandler<UpdateMenuCommandRequest,ResponseModel<UpdateMenuCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Page.PageEntity> _pageEntity;

    public UpdateMenuCommandHandler(IGenericRepository<PageEntity> pageEntity)
    {
        _pageEntity = pageEntity;
    }

    public async Task<ResponseModel<UpdateMenuCommandResponse>> Handle(UpdateMenuCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == null || request.IsPublished == null)
        {
            return ResponseModel<UpdateMenuCommandResponse>.Fail("Id or IsPublished is null");
        }
        var findPage = await _pageEntity.GetByIdAsync(request.Id);
        if (findPage == null)
        {
            return ResponseModel<UpdateMenuCommandResponse>.Fail("Page not found");
        }
        findPage.IsPublished = request.IsPublished;
        _pageEntity.Update(findPage);
        return ResponseModel<UpdateMenuCommandResponse>.Success("Success");

    }
}