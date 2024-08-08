using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace EduConnect.API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddLocalizationOptions(this IServiceCollection services)
    {
        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en-GB"),
                new CultureInfo("en-US"),
                new CultureInfo("en"),
                new CultureInfo("fr-FR"),
                new CultureInfo("fr"),
                new CultureInfo("ar-EG")
            };
            options.DefaultRequestCulture = new RequestCulture("en-US");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });

        return services;
    }
}
