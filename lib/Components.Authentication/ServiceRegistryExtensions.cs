using Components.Authentication.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegistryExtensions
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
        {
            services.AddSingleton<AuthenticationStateProvider>(sp =>
            {
                return new DefaultAuthenticationStateProvider();
            });

            return services;
        }
    }
}
