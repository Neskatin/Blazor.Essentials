using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.Essentials.Storage
{
    public class LocalStorage : ILocalStorage
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public LocalStorage(IJSRuntime jsRuntime)
        {
            _moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Blazor.Essentials.Storage/LocalStorageJsInterop.js").AsTask());
        }

        public async ValueTask<bool> IsSupportedAsync(CancellationToken token = default)
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<bool>("isSupported", token);
        }

        public async ValueTask SetItemAsync<TType>(string key, TType item, CancellationToken token = default)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("setItem", token, key, item);
        }

        public async ValueTask<TType> GetItemAsync<TType>(string key, CancellationToken token = default)
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<TType>("getItem", token, key);
        }

        public async ValueTask RemoveItemAsync(string key, CancellationToken token = default)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("removeItem", token, key);
        }

        public async ValueTask ClearAsync(CancellationToken token = default)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("clear", token);
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