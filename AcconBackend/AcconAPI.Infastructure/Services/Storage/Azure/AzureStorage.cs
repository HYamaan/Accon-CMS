using AcconAPI.Application.Services.Storage.Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace AcconAPI.Infastructure.Services.Storage.Azure;

public class AzureStorage : Storage, IAzureStorage
{
    readonly BlobServiceClient _blobServiceClient;
    BlobContainerClient _blobContainerClient;
    public AzureStorage(IConfiguration configuration)
    {
        _blobServiceClient = new(configuration["Storage:Azure"]);
    }


    public async Task DeleteAsync(string containerName, string fileName)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
        await blobClient.DeleteAsync();
    }

    public List<string> GetFiles(string containerName)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
    }

    public new bool HasFile(string containerName, string fileName)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
    }

    public async Task<(string fileName, string pathOrContainerName)> UploadAsync(string containerName, IFormFile file)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        await _blobContainerClient.CreateIfNotExistsAsync();
        await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

        string fileNewName = await FileRenameAsync(containerName, file.Name, HasFile);

        BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);
        await blobClient.UploadAsync(file.OpenReadStream());
        return (fileNewName, $"{containerName}/{fileNewName}");
    }


}