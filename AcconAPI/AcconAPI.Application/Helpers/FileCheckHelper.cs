using AcconAPI.Application.Services.Helpers;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Application.Helpers;

public class FileCheckHelper:IFileCheckHelper
{
    public async Task<bool> CheckImageFormat(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return false;
        }

        var fileExtension = Path.GetExtension(file.FileName);
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
        if (!allowedExtensions.Contains(fileExtension.ToLower()))
        {
            return false;
        }

        try
        {
            using (var stream = file.OpenReadStream())
            {
                var buffer = new byte[4];
                await stream.ReadAsync(buffer, 0, buffer.Length);

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg")
                {
                    if (buffer[0] == 0xFF && buffer[1] == 0xD8 && buffer[2] == 0xFF)
                    {
                        return true;
                    }
                }
                else if (fileExtension.ToLower() == ".png")
                {
                    if (buffer[0] == 0x89 && buffer[1] == 0x50 && buffer[2] == 0x4E && buffer[3] == 0x47)
                    {
                        return true;
                    }
                }
                else if (fileExtension.ToLower() == ".gif")
                {
                    if (buffer[0] == 0x47 && buffer[1] == 0x49 && buffer[2] == 0x46 && buffer[3] == 0x38)
                    {
                        return true;
                    }
                }
                else if (fileExtension.ToLower() == ".bmp")
                {
                    if (buffer[0] == 0x42 && buffer[1] == 0x4D)
                    {
                        return true;
                    }
                }
                else if (fileExtension.ToLower() == ".svg")
                {
                    // Stream'in başındaki daha fazla baytı okuyun çünkü <?xml veya <svg etiketini kontrol etmeniz gerekebilir.
                    var svgBuffer = new byte[5];
                    await stream.ReadAsync(svgBuffer, 0, svgBuffer.Length);

                    var header = System.Text.Encoding.UTF8.GetString(svgBuffer);
                    if (header.StartsWith("<?xml") || header.StartsWith("<svg"))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        catch
        {
            return false;
        }
    }
}