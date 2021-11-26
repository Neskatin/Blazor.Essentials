using Microsoft.JSInterop;

namespace Blazor.Essentials.MediaQuery
{
    public class NotificationHandler
    {
        private readonly MediaQuery _observer;

        public NotificationHandler(MediaQuery observer)
        {
            _observer = observer;
        }

        [JSInvokable]
        public void HandleMediaQueryValueChanged(MediaQueryList query)
        {
            _observer.TriggerNotification(query);
        }
    }
}