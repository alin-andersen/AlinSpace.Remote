using Microsoft.AspNetCore.SignalR.Client;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text.Json;

namespace AlinSpace.Remote.Client
{
    public class EventSource : IAsyncDisposable
    {
        private HubConnection hubConnection;
        private Subject<Event> subject = new();

        public IObservable<Event> Event => subject.AsObservable();

        public EventSource(Uri host, Action<IHubConnectionBuilder> configure = null)
        {
            var hubConnectionBuilder = new HubConnectionBuilder()
                .WithAutomaticReconnect()
                .WithUrl(host);

            configure?.Invoke(hubConnectionBuilder);

            hubConnection = hubConnectionBuilder.Build();

            hubConnection.On<string>("Event", OnReceivedEvent);
        }

        private void OnReceivedEvent(string @event)
        {
            subject.OnNext(JsonSerializer.Deserialize<Event>(@event));
        }

        public async Task StartAsync()
        {
            await hubConnection.StartAsync();
        }

        public async Task StopAsync()
        {
            await hubConnection.StopAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if (hubConnection != null)
            {
                await hubConnection.DisposeAsync();
            }

            subject?.Dispose();
            subject = null;
        }
    }
}
