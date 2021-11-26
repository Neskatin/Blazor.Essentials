using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Essentials.Dialog
{
    public interface IDialog : IAsyncDisposable
    {
        ValueTask<string> PromptAsync(string? message = null, string? defaultValue = null,
            CancellationToken token = default);

        ValueTask<bool> ConfirmAsync(string message, CancellationToken token = default);
    }
}