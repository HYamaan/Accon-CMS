using AcconAPI.Application.Services;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Infastructure.Services.Storage;
using AcconAPI.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcconAPI.Infastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddScoped<IMailService, MailService>();
        serviceCollection.AddScoped<IStorageService,StorageService> ();

    }
    public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
    {
        serviceCollection.AddScoped<IStorage, T>();
    }
}