using AcconAPI.Application.Repository;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Queries.Settings.LoginBackground;

public class LoginBackgroundQueryHandler:IRequestHandler<LoginBackgroundQueryRequest,ResponseModel<LoginBackgroundQueryResponse>>
{
    private readonly IGenericRepository<Domain.Entities.File.Settings.LoginBackground> _loginBackgroundRepository;

    public LoginBackgroundQueryHandler(IGenericRepository<Domain.Entities.File.Settings.LoginBackground> loginBackgroundRepository)
    {
        _loginBackgroundRepository = loginBackgroundRepository;
    }

    public async Task<ResponseModel<LoginBackgroundQueryResponse>> Handle(LoginBackgroundQueryRequest request, CancellationToken cancellationToken)
    {
        var result= await _loginBackgroundRepository.GetAll().OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync();

        if (result == null)
        {
            return ResponseModel<LoginBackgroundQueryResponse>.Fail("No Login Background Found");
        }

        return ResponseModel<LoginBackgroundQueryResponse>.Success(new LoginBackgroundQueryResponse
        {
            Photo = result.Path,
        });
    }
}