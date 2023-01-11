using AlinSpace.Remote.Client;
using AlinSpace.Remote.Test.Shared;
using System.Reactive.Linq;

namespace AlinSpace.Remote.TestClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var eventSource = new EventSource(new Uri("http://localhost:5086/hub"));

            eventSource
                .Event
                .Where<SomeEvent>()
                .Subscribe(x =>
                {
                    Console.WriteLine(x.Number);
                });

            await eventSource.StartAsync();

            var connector = Connector.New(new Uri("http://localhost:5086/"));

            var ping = connector.GetApi<IPing>();

            var t2 = await ping.PingAsync(new PingRequest());
            t2 = await ping.PingAsync(new PingRequest());
            t2 = await ping.PingAsync(new PingRequest());
            t2 = await ping.PingAsync(new PingRequest());
            t2 = await ping.PingAsync(new PingRequest());
            t2 = await ping.PingAsync(new PingRequest());



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

            await Task.Delay(100000000);

            await eventSource.DisposeAsync();
        }
    }
}