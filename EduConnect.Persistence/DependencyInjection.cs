using EduConnect.Application.Abstractions.Interfaces.Persistence;
using EduConnect.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduConnect.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistencePart(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITopicRepository, TopicRepository>();

            return services;

        }
    }
}
