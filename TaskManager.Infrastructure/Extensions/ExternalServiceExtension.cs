using Microsoft.Extensions.DependencyInjection;
using TaskManager.Domain.Contracts;
using Microsoft.Extensions.Configuration;
using TaskManager.Infrastructure.ExternalServices;
using TaskManager.Infrastructure.Repository;

namespace TaskManager.Infrastructure.Extensions
{
    public static class ExternalServiceExtension
    {
        public static IServiceCollection RegisterExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IExternalMockService, ExternalMockService>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<ITodoRepository, TodoRepository>();  
            
            return services;
        }
    }
}
