
using AcconAPI.Application.Abstraction;
using AcconAPI.Application.Repository;
using AcconAPI.Domain.Auth;
using AcconAPI.Persistence.Context;
using AcconAPI.Persistence.Extension;
using AcconAPI.Persistence.Repository;
using AcconAPI.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcconAPI.Persistence.Registration;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AcconAPIDbContext>(options => options.UseNpgsql(configuration["ConnectionStrings:PostgreSQL"]));
        services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 3;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@.-_+";

            }).AddEntityFrameworkStores<AcconAPIDbContext>()
            .AddDefaultTokenProviders();

        services.AddSwaggerOpenAPI();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<ITokenHandler, TokenHandler>();
    }
}