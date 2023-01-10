using AlinSpace.Remote.Client;
using Microsoft.AspNetCore.SignalR.Client;
using System.Reactive.Subjects;
using System.Text.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text.Json;
using AlinSpace.Remote.Test.Shared;

namespace AlinSpace.Remote.TestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = new EventSource(new Uri("http://localhost:5086/hub"));
            t.StartAsync().Wait();

            t.Event.Where<SomeEvent>().Subscribe(x =>
            {

            });

            var connector = Connector.New(new Uri("http://localhost:5086/"));

            var ping = connector.GetApi<IPing>();

            var t2 = ping.PingAsync(new PingRequest()).Result;
            //var request = new SimpleFileUploadRequest();

            //FileLoader.UploadAsync("Test.txt", async (slice, cancellationToken) =>
            //{
            //    request.File = slice;

            //    var response = await simpleFile.UploadAsync(request);

            //    if (!response.IsSuccess)
            //    {
            //        throw new Exception();
            //    }
            //}).Wait();

            Thread.Sleep(100000);
        }
    }




        public class EventSource : IAsyncDisposable
        {
            private HubConnection hubConnection;
            private Subject<Event> subject = new();

            public IObservable<Event> Event => subject.AsObservable();

            public EventSource(Uri host, Action<IHubConnectionBuilder> configure = null)
            {
                var hubConnectionBuilder = new HubConnectionBuilder()
                    //.WithAutomaticReconnect()
                    .WithUrl(host);

                configure?.Invoke(hubConnectionBuilder);

                hubConnection = hubConnectionBuilder.Build();
            hubConnection.Reconnecting += HubConnection_Reconnecting;
                hubConnection.Reconnected += HubConnection_Reconnected;
            hubConnection.Closed += HubConnection_Closed; ;

            hubConnection.On<string>("Event", OnReceivedEvent);
            }

        private Task HubConnection_Closed(Exception? arg)
        {
            return Task.CompletedTask;
        }

        private Task HubConnection_Reconnecting(Exception? arg)
        {
            return Task.CompletedTask;
        }

        private Task HubConnection_Reconnected(string? arg)
        {
            return Task.CompletedTask;
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