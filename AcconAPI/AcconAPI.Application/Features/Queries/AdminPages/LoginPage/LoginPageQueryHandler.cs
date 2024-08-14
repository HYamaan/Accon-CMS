using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.AdminPages.LoginPage;

public class LoginPageQueryHandler : IRequestHandler<LoginPageQueryRequest, ResponseModel<LoginPageQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.Settings.AdminLogo> _webSiteLogoRepository;
    private readonly IGenericRepository<Domain.Entities.File.Settings.LoginBackground> _loginBackgroundRepository;


    public LoginPageQueryHandler(IGenericRepository<AdminLogo> webSiteLogoRepository, IGenericRepository<LoginBackground> loginBackgroundRepository)
    {
        _webSiteLogoRepository = webSiteLogoRepository;
        _loginBackgroundRepository = loginBackgroundRepository;
    }

    public async Task<ResponseModel<LoginPageQueryResponse>> Handle(LoginPageQueryRequest request, CancellationToken cancellationToken)
    {
        var webSiteLogo = await _webSiteLogoRepository.GetAll().OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync() ?? null;
        var loginBackground = await _loginBackgroundRepository.GetAll().OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync() ?? null;

        return ResponseModel<LoginPageQueryResponse>.Success(new LoginPageQueryResponse()
        {
            WebSiteLogo = webSiteLogo?.Path,
            LoginBackground = loginBackground?.Path
        });
    }
}