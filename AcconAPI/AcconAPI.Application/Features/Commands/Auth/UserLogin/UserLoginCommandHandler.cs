using AcconAPI.Application.Abstraction;
using AcconAPI.Application.Models.DTOs.Response.Auth;
using AcconAPI.Domain.Auth;
using AcconAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AcconAPI.Application.Features.Commands.Auth.UserLogin;

public class UserLoginCommandHandler:IRequestHandler<UserLoginCommandRequest, ResponseModel<UserLoginCommandResponse>>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenHandler _tokenHandler;

    public UserLoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenHandler = tokenHandler;
    }

    public async Task<ResponseModel<UserLoginCommandResponse>> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return ResponseModel<UserLoginCommandResponse>.Fail("User not found");
        SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!signInResult.Succeeded)
            return ResponseModel<UserLoginCommandResponse>.Fail("Invalid password");

        TokenDTO token = await _tokenHandler.GenerateJWToken(user);



        return ResponseModel<UserLoginCommandResponse>.Success(new UserLoginCommandResponse()
        {
            AccessToken = token.AccessToken,
            AccessTokenExpiration = token.AccessTokenExpiration
        });
    }
}