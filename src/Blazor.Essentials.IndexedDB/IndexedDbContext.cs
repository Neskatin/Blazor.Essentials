using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.Essentials.IndexedDB
{
    public abstract class IndexedDbContext : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        protected IndexedDbContext(IJSRuntime jsRuntime)
        {
            _moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Blazor.Essentials.IndexedDB/IndexedDBJsInterop.js").AsTask());
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