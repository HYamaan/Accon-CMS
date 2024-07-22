using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Settings.Favicon;

public class FaviconQueryHandler:IRequestHandler<FaviconQueryRequest, ResponseModel<FaviconQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.Settings.Favicon> _faviconRepositorty;

    public FaviconQueryHandler(IGenericRepository<Domain.Entities.File.Settings.Favicon> faviconRepositorty)
    {
        _faviconRepositorty = faviconRepositorty;
    }

    public async Task<ResponseModel<FaviconQueryResponse>> Handle(FaviconQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _faviconRepositorty.GetAll().FirstOrDefaultAsync();
        if (result == null)
        {
            return ResponseModel<FaviconQueryResponse>.Fail("Favicon not found");
        }

        return ResponseModel<FaviconQueryResponse>.Success(new FaviconQueryResponse()
        {
            Favicon = result.Path
        });
    }
}