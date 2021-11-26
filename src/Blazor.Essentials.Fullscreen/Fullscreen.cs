using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.Essentials.Fullscreen
{
    public class Fullscreen : IFullscreen
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public Fullscreen(IJSRuntime jsRuntime)
        {
            _moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Blazor.Essentials.Fullscreen/FullscreenJsInterop.js").AsTask());
        }

        public async ValueTask<bool> IsSupportedAsync(CancellationToken token = default)
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<bool>("isSupported", token);
        }

        public async ValueTask RequestDocumentFullscreenAsync(CancellationToken token = default)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("requestDocumentFullscreen", token);
        }

        public async ValueTask RequestElementFullscreenAsync(string elementId, CancellationToken token = default)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("requestElementFullscreen", token, elementId);
        }

        public async ValueTask ExitFullscreenAsync(CancellationToken token = default)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("exitFullscreenRequest", token);
        }

        public async ValueTask ToggleDocumentFullscreenAsync(CancellationToken token = default)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("toggleDocumentFullscreen", token);
        }

        public async ValueTask DisposeAsync()
        {
            if (_moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}