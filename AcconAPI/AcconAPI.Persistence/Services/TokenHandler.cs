using System.IdentityModel.Tokens.Jwt;
using AcconAPI.Domain.Auth;
using AcconAPI.Domain.Settings;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AcconAPI.Application.Abstraction;
using AcconAPI.Application.Models.DTOs.Response.Auth;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using Microsoft.Extensions.Options;

namespace AcconAPI.Persistence.Services;

public class TokenHandler:ITokenHandler
{
    private readonly UserManager<AppUser> _userManager;
    private readonly JWTSettings _jwtSettings;

    public TokenHandler(UserManager<AppUser> userManager, IOptions<JWTSettings> jwtSettings)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings.Value;
    }
    private string RandomTokenString()
    {
        using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
        var randomBytes = new byte[40];
        rngCryptoServiceProvider.GetBytes(randomBytes);
        // convert random bytes to hex string
        return BitConverter.ToString(randomBytes).Replace("-", "");
    }

    private async Task<IEnumerable<Claim>> GetClaims(AppUser user, string audiences)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);

        var userList = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Aud, audiences),
            }
            .Union(userClaims);

        return userList;
    }

    public async Task<TokenDTO> GenerateJWToken(AppUser user)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var accessTokenExpiration = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpiration);
        var getClaims = await GetClaims(user, _jwtSettings.Audience);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            expires: accessTokenExpiration,
            claims: getClaims,
            signingCredentials: signingCredentials);

        var handler = new JwtSecurityTokenHandler();
        var token = handler.WriteToken(jwtSecurityToken);
        var tokenDto = new TokenDTO()
        {
            AccessToken = token,
            AccessTokenExpiration = accessTokenExpiration
        };
        return tokenDto;
    }
}