using Microsoft.Extensions.Options;

namespace EduConnect.API.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseLocalization(this WebApplication app)
    {
        app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
        return app;
    }
}
