using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Essentials.MediaQuery
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBlazorEssentialsMediaQuery(this IServiceCollection services)
        {
            return services.AddTransient<IMediaQuery, MediaQuery>();
        }
    }
}