using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Settings.Logo;

public class LogoQueryHandler:IRequestHandler<LogoQueryRequest, ResponseModel<LogoQueryResponse>>
{
    private readonly IGenericRepository<WebSiteLogo> _webSiteLogoRepository;
    private readonly IGenericRepository<AdminLogo> _adminLogoRepository;

    public LogoQueryHandler(IGenericRepository<WebSiteLogo> webSiteLogoRepository, IGenericRepository<AdminLogo> adminLogoRepository)
    {
        _webSiteLogoRepository = webSiteLogoRepository;
        _adminLogoRepository = adminLogoRepository;
    }

    public async Task<ResponseModel<LogoQueryResponse>> Handle(LogoQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var adminLogo = await _adminLogoRepository.GetAll().OrderByDescending(x=>x.CreatedDate).FirstOrDefaultAsync();
            var webSiteLogo = await _webSiteLogoRepository.GetAll().OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync();

            var response = new LogoQueryResponse
            {
                AdminLogo = adminLogo.Path,
                WebsiteLogo = webSiteLogo.Path
            };

            return ResponseModel<LogoQueryResponse>.Success(response);
        }
        catch (Exception e)
        {
           return ResponseModel<LogoQueryResponse>.Fail(e.Message);
        }
    }
}