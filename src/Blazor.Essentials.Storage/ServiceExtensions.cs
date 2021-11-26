using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Essentials.Storage
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBlazorEssentialsSessionStorage(this IServiceCollection services)
        {
            return services.AddTransient<ISessionStorage, SessionStorage>();
        }

        public static IServiceCollection AddBlazorEssentialsLocalStorage(this IServiceCollection services)
        {
            return services.AddTransient<ILocalStorage, LocalStorage>();
        }

        public static IServiceCollection AddBlazorEssentialsStorage(this IServiceCollection services)
        {
            services.AddTransient<ILocalStorage, LocalStorage>();
            services.AddTransient<ISessionStorage, SessionStorage>();

            return services;
        }
    }
}