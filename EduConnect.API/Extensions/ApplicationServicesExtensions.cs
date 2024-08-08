using EduConnect.API.Localization;
using EduConnect.Application;
using EduConnect.Identity;
using EduConnect.Infrastructure;
using EduConnect.Persistence;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace EduConnect.API.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPersistencePart(configuration)
            .AddApplicationPart()
            .AddIdentityPart()
            .AddInfrastructurePart()
            .AddDistributedMemoryCache()
            .AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>()
            .AddLocalization(opt => opt.ResourcesPath = $"{Directory.GetCurrentDirectory()}/Resources")
            .Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("en"),
                    new CultureInfo("ar-EG")
                };

                options.DefaultRequestCulture = new RequestCulture(supportedCultures[0]);
                options.SupportedCultures = supportedCultures;
            });

        return services;
    }
}
