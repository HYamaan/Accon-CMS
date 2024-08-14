using AcconAPI.Application.Models.DTOs.Response.Auth;
using AcconAPI.Domain.Auth;
namespace AcconAPI.Application.Abstraction;

public interface ITokenHandler
{
    Task<TokenDTO> GenerateJWToken(AppUser user);
}