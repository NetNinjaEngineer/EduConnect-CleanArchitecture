using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EduConnect.Application
{
    public static class ApplicationServicesRegisteration
    {
        public static IServiceCollection AddApplicationPart(this IServiceCollection services)
        {
            services.AddMediatR(options =>
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
