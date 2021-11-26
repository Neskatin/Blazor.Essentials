using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.Essentials.MediaQuery
{
    public class MediaQuery : IMediaQuery
    {
        public event EventHandler<MediaQueryList>? Notification;
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
        private DotNetObjectReference<NotificationHandler>? _notificationHandler;

        public MediaQuery(IJSRuntime jsRuntime)
        {
            _moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Blazor.Essentials.MediaQuery/MediaQueryJsInterop.js").AsTask());
        }

        public async ValueTask<bool> IsSupportedAsync(CancellationToken token = default)
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<bool>("isSupported", token);
        }

        public async ValueTask<bool> IsMatchedAsync(string query, CancellationToken token = default)
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<bool>("isMatched", token, query);
        }

        public async ValueTask ObserveAsync(string query, CancellationToken token = default)
        {
            await ObserveAsync(new[] { query }, token);
        }

        public async ValueTask ObserveAsync(string[] queries, CancellationToken token = default)
        {
            _notificationHandler ??= DotNetObjectReference.Create(new NotificationHandler(this));

            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("observe", token, queries, _notificationHandler);
        }

        public void TriggerNotification(MediaQueryList query)
        {
            Notification?.Invoke(this, query);
        }

        public async ValueTask DisposeAsync()
        {
            if (_moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.InvokeVoidAsync("dispose");
                await module.DisposeAsync();
            }
        }
    }
}