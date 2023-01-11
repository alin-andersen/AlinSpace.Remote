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
        private Subject<string> reconnectedSubject = new();

        public string ConnectionId { get; private set; }

        public IObservable<Event> WhenEvent => subject.AsObservable();

        public IObservable<string> WhenReconnected => reconnectedSubject.AsObservable();

        public EventSource(Uri host, Action<IHubConnectionBuilder> configure = null)
        {
            var hubConnectionBuilder = new HubConnectionBuilder()
                .WithAutomaticReconnect()
                .WithUrl(host);

            configure?.Invoke(hubConnectionBuilder);

            hubConnection = hubConnectionBuilder.Build();
            hubConnection.On<string>(nameof(Remote.Event), OnReceivedEvent);
            hubConnection.Reconnected += OnReconnected;
        }

        private Task OnReconnected(string connectionId)
        {
            ConnectionId = connectionId;
            reconnectedSubject.OnNext(ConnectionId);

            return Task.CompletedTask;
        }

        private void OnReceivedEvent(string @event)
        {
            subject.OnNext(JsonSerializer.Deserialize<Event>(@event));
        }

        public async Task StartAsync()
        {
            await hubConnection.StartAsync();

            ConnectionId = hubConnection.ConnectionId;
        }

        public async Task StopAsync()
        {
            ConnectionId = null;

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
