using AcconAPI.Application.Services.Storage;
using Microsoft.AspNetCore.Http;

namespace AcconAPI.Infastructure.Services.Storage;

public class StorageService : IStorageService
{
    readonly IStorage _storage;

    public StorageService(IStorage storage)
    {
        _storage = storage;
    }

    public string StorageName
    {
        get => _storage.GetType().Name;
    }



    public async Task DeleteAsync(string pathOrContainerName, string fileName)
        => await _storage.DeleteAsync(pathOrContainerName, fileName);

    public List<string> GetFiles(string pathOrContainerName)
        => _storage.GetFiles(pathOrContainerName);

    public bool HasFile(string pathOrContainerName, string fileName)
        => _storage.HasFile(pathOrContainerName, fileName);

    public Task<(string fileName, string pathOrContainerName)> UploadAsync(string pathOrContainerName,
        IFormFile file)
        => _storage.UploadAsync(pathOrContainerName, file);

}