using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AcconAPI.Persistence.Extension;

public static class ConfigureServiceContainer
{
    public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(setupAction =>
        {
            setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Description = $"Input your Bearer token in this format - Bearer token to access this API",
            });
            setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                    }, new List<string>()
                },
            });
        });

    }
}