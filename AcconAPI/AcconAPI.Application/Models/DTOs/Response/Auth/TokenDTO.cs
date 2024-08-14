namespace AcconAPI.Application.Models.DTOs.Response.Auth;

public class TokenDTO
{
    public string AccessToken { get; set; }

    public DateTime AccessTokenExpiration { get; set; }

}