using Microsoft.Extensions.DependencyInjection;

namespace EduConnect.Application
{
    public static class ApplicationServicesRegisteration
    {
        public static IServiceCollection AddApplicationPart(this IServiceCollection services)
        {
            return services;
        }
    }
}
