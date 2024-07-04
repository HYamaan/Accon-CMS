namespace AcconAPI.Domain.Settings;
public class JWTSettings
{
    public string SecurityKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public double AccessTokenExpiration { get; set; }
    public int RefreshTokenExpiration { get; set; }

}