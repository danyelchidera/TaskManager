using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Shared.OptionsObject;

namespace TaskManager.Service.Extensions
{
    public static class OptionsConfiguration
    {
        public static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MockApiConfig>(configuration.GetSection(nameof(MockApiConfig)));

            return services;
        }
    }
}
