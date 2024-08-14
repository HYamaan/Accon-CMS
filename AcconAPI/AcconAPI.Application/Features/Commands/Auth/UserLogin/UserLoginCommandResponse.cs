namespace AcconAPI.Application.Features.Commands.Auth.UserLogin;

public class UserLoginCommandResponse
{
    public string AccessToken { get; set; }
    public DateTime AccessTokenExpiration { get; set; }
}