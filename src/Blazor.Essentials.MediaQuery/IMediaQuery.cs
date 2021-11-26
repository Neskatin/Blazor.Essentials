using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Essentials.MediaQuery
{
    public interface IMediaQuery : IAsyncDisposable
    {
        event EventHandler<MediaQueryList>? Notification;

        ValueTask<bool> IsSupportedAsync(CancellationToken token = default);

        ValueTask<bool> IsMatchedAsync(string query, CancellationToken token = default);

        ValueTask ObserveAsync(string query, CancellationToken token = default);

        ValueTask ObserveAsync(string[] queries, CancellationToken token = default);
    }
}