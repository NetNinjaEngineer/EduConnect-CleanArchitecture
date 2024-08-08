using Microsoft.AspNetCore.Builder;

namespace EduConnect.Application;

public static class WebApplicationExtensions
{
    public static WebApplication UseLocalizationOptions(this WebApplication app)
    {
        var supportedCultures = new[] { "en-US", "ar-EG", "en" };
        var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures);

        app.UseRequestLocalization(localizationOptions);
        return app;
    }
}
