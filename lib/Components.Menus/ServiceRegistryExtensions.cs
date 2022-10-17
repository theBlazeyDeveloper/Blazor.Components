using Components.Menus.Models.Providers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegistryExtensions
    {
        public static IServiceCollection AddMenuServices(this IServiceCollection services)
        {
            services.AddSingleton(sp =>
            {
                return new VerticalMenuStateProvider();
            });

            return services;
        }
    }
}
