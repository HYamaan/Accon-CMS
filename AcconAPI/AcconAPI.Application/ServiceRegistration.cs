using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text;
using AcconAPI.Application.FluentValidation;
using AcconAPI.Application.Helpers;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using FluentValidation;
using AcconAPI.Application.Mapping;
using AcconAPI.Application.Services.FluentValidation;
using AcconAPI.Application.Features.Commands.PhotoGallery.UpdateGallery;
using static AcconAPI.Application.FluentValidation.TeamMemberCommandRequestValidator;
using static AcconAPI.Application.FluentValidation.TestimonialCommandRequestValidator;
using static AcconAPI.Application.FluentValidation.WhyChooseUsRequestValidator;
using static AcconAPI.Application.FluentValidation.NewsCommandRequestValidator;

namespace AcconAPI.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.RequireHttpsMetadata = false;
            o.SaveToken = false;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JWTSettings:Issuer"],
                ValidAudience = configuration["JWTSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:SecurityKey"]))
            };
            o.Events = new JwtBearerEvents()
            {
                OnAuthenticationFailed = c =>
                {
                    c.NoResult();
                    c.Response.StatusCode = 500;
                    c.Response.ContentType = "text/plain";
                    return c.Response.WriteAsync(c.Exception.ToString());
                },
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json";
                    var result = JsonConvert.SerializeObject(ResponseModel<string>.Fail("You are not Authorized"));
                    return context.Response.WriteAsync(result);
                },
                OnForbidden = context =>
                {
                    context.Response.StatusCode = 403;
                    context.Response.ContentType = "application/json";
                    var result = JsonConvert.SerializeObject(ResponseModel<string>.Fail("You are not authorized to access this resource"));
                    return context.Response.WriteAsync(result);
                },
            };
        });
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IFileCheckHelper, FileCheckHelper>();
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddValidatorsFromAssembly(typeof(AboutPageCommandRequestValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(PageEntityCommandRequestValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(PageEntityWithContentRequestValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(UpdateSliderCommandRequestValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(PortfolioCategoryValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(DesignationValidator).Assembly);
        services.AddTransient<IUpdateServiceCommandRequestValidator, UpdateServiceCommandRequestValidator>();
        services.AddTransient<IUpdateServiceContentCommandRequestValidator, UpdateServiceContentCommandRequestValidator>();

        services.AddTransient<IUpdatePhotoGalleryValidator, GaleryPhotoCommandRequestValidator.UpdatePhotoGalleryValidator>();
        services.AddTransient<ICreatePhotoGalleryValidator, GaleryPhotoCommandRequestValidator.CreatePhotoGalleryValidator>();

        services.AddTransient<ICreateTeamMemberCommandRequestValidator, CreateTeamMemberCommandRequestValidator>();
        services.AddTransient<IUpdateTeamMemberCommandRequestValidator, UpdateTeamMemberCommandRequestValidator>();

        services.AddTransient<ICreateTestimonialCommandRequestValidator, CreateTestimonialCommandRequestValidator>();
        services.AddTransient<IUpdateTestimonialCommandRequestValidator, UpdateTestimonialCommandRequestValidator>();

        services.AddTransient<ICreateWhyChooseUsCommandRequestValidator, CreateWhyChooseUsCommandRequestValidator>();
        services.AddTransient<IUpdateWhyChooseUsCommandRequestValidator, UpdateWhyChooseUsCommandRequestValidator>();

        services.AddTransient<ICreateNewsCommandRequestValidator, CreateNewsCommandRequestValidator>();
        services.AddTransient<IUpdateNewsCommandRequestValidator, UpdateNewsCommandRequestValidator>();

        services.AddTransient<ICreateLanguageCommandRequestValidator,LanguageCommandRequestValidator.CreateLanguageCommandRequestValidator>();
        services.AddTransient<IUpdateLanguageCommandRequestValidator,LanguageCommandRequestValidator.UpdateLanguageCommandRequestValidator>();

        services
            .AddTransient<ICreateSocialMediaCommandRequestValidator,
                SocialMediaCommandRequestValidator.CreateSocialMediaCommandRequestValidator>();
        services
            .AddTransient<IUpdateSocialMediaCommandRequestValidator,
                SocialMediaCommandRequestValidator.UpdateSocialMediaCommandRequestValidator>();

        services.AddTransient<IUpdateMenuCommandRequestValidator, UpdateMenuCommandRequestValidator>();
    }
}