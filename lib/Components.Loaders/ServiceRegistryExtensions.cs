using Components.Loaders.Models.Interfaces;
using Components.Loaders.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegistryExtensions
    {
        public static IServiceCollection AddLoaderServices(this IServiceCollection services)
        {
            services.AddSingleton<ITimerService>(sp =>
            {
                return new TimerService();
            });

            return services;
        }
    }
}
