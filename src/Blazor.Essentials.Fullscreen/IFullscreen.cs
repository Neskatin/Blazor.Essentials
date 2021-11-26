using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Essentials.Fullscreen
{
    public interface IFullscreen : IAsyncDisposable
    {
        ValueTask<bool> IsSupportedAsync(CancellationToken token = default);
        ValueTask RequestDocumentFullscreenAsync(CancellationToken token = default);
        ValueTask RequestElementFullscreenAsync(string elementId, CancellationToken token = default);
        ValueTask ExitFullscreenAsync(CancellationToken token = default);
        ValueTask ToggleDocumentFullscreenAsync(CancellationToken token = default);
    }
}