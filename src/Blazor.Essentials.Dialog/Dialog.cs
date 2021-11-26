using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.Essentials.Dialog
{
    public class Dialog : IDialog
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public Dialog(IJSRuntime jsRuntime)
        {
            _moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Blazor.Essentials.Dialog/DialogJsInterop.js").AsTask());
        }

        public async ValueTask<string> PromptAsync(string? message = null, string? defaultValue = null,
            CancellationToken token = default)
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<string>("showPrompt", token, message, defaultValue);
        }

        public async ValueTask<bool> ConfirmAsync(string message, CancellationToken token = default)
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<bool>("showConfirm", token, message);
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