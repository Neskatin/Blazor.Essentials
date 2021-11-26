using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Essentials.Dialog;
using Blazor.Essentials.Fullscreen;
using Blazor.Essentials.MediaQuery;
using Blazor.Essentials.Storage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Essentials.Sample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient
                { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazorEssentialsMediaQuery();
            builder.Services.AddBlazorEssentialsStorage();
            builder.Services.AddBlazorEssentialsDialog();
            builder.Services.AddBlazorEssentialsFullscreen();

            await builder.Build().RunAsync();
        }
    }
}