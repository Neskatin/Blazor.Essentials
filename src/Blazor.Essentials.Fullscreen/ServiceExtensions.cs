using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Essentials.Fullscreen
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBlazorEssentialsFullscreen(this IServiceCollection services)
        {
            return services.AddTransient<IFullscreen, Fullscreen>();
        }
    }
}