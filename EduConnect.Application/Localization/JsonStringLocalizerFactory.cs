using Microsoft.Extensions.Localization;

namespace EduConnect.Application.Localization;
public class JsonStringLocalizerFactory : IStringLocalizerFactory
{
    public IStringLocalizer Create(Type resourceSource)
    {
        return new JsonStringLocalizer();
    }

    public IStringLocalizer Create(string baseName, string location)
    {
        return new JsonStringLocalizer();
    }
}
