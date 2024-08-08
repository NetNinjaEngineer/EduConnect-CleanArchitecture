using EduConnect.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EduConnect.API.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureWebApplication(this WebApplication app)
    {

        var supportedCultures = new[] { "en-US", "ar-EG", "en" };
        var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures);

        app.UseRequestLocalization(localizationOptions);


        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();

        return app;
    }
}
