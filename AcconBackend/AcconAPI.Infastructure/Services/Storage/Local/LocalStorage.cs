using AcconAPI.Application.Services.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Infastructure.Services.Storage.Local;

public class LocalStorage:Storage,ILocalStorage
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private string _uploadPath = @"D:\Repos\Work\Accon-CMS\AcconClient\public\files";
    public LocalStorage(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }


    public async Task DeleteAsync(string path, string fileName)
    {
        var filePath = Path.Combine(_uploadPath, fileName);
        var bool2 = File.Exists(filePath);
        if (File.Exists(filePath))
        {
            await Task.Run(() => System.IO.File.Delete(filePath));
        }
    }


    public List<string> GetFiles(string path)
    {
        DirectoryInfo directory = new(path);
        return directory.GetFiles().Select(f => f.Name).ToList();
    }

    public new bool HasFile(string path, string fileName)
    {
        string filePath = Path.Combine(_uploadPath, fileName);
        return File.Exists(filePath);
    }

    async Task<bool> CopyFileAsync(string path, IFormFile file)
    {
        try
        {
            await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            return true;
        }
        catch (Exception ex)
        {
            //todo log!
            throw ex;
        }
    }
    public async Task<(string fileName, string pathOrContainerName)> UploadAsync(string path, IFormFile file)
    {
        // string _uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(_uploadPath))
            Directory.CreateDirectory(_uploadPath);

        string fileNewName = await FileRenameAsync(path, file.FileName, HasFile);
        await CopyFileAsync(Path.Combine(_uploadPath, fileNewName), file);
        return (fileNewName, $"{path}/{fileNewName}");
    }

}