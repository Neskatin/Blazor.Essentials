using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Essentials.Dialog
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBlazorEssentialsDialog(this IServiceCollection services)
        {
            return services.AddTransient<IDialog, Dialog>();
        }
    }
}