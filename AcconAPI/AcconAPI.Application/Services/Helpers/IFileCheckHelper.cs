using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Services.Helpers;

public interface IFileCheckHelper
{
    Task<bool> CheckImageFormat(IFormFile file);
}