using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Essentials.Storage
{
    public interface ILocalStorage : IAsyncDisposable
    {
        ValueTask<bool> IsSupportedAsync(CancellationToken token = default);
        ValueTask SetItemAsync<TType>(string key, TType item, CancellationToken token = default);
        ValueTask<TType> GetItemAsync<TType>(string key, CancellationToken token = default);
        ValueTask RemoveItemAsync(string key, CancellationToken token = default);
        ValueTask ClearAsync(CancellationToken token = default);
    }
}