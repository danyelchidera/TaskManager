using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Domain.Contracts;
using TaskManager.Service.Mappings;
using TaskManager.Service.Services;
using TaskManager.ServiceContracts.Contracts;

namespace TaskManager.Service.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(TodoMapping));
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<ITodoService, TodoService>();

            return services;
        }
    }
}
