using EduConnect.Application.DTOs.Topic.Validators;
using EduConnect.Application.Localization;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Reflection;

namespace EduConnect.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationPart(this IServiceCollection services)
        {
            services.AddMediatR(options =>
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblyContaining<CreateTopicCommandValidator>();
            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("en"),
                    new CultureInfo("ar-EG")
                };

                options.DefaultRequestCulture = new RequestCulture(supportedCultures[0], supportedCultures[0]);
                options.SupportedCultures = supportedCultures;
            });


            return services;
        }
    }
}
