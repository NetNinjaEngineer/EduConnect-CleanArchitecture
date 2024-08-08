using EduConnect.Application.DTOs.Topic.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
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

            return services;
        }
    }
}
