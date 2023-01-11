using AlinSpace.Remote.Server;
using AlinSpace.Remote.Server.AspNetCore;
using AlinSpace.Remote.Test.Shared;
using Microsoft.AspNetCore.SignalR;

namespace AlinSpace.Remote.TestServer.AspNetCore
{
    public class DefaultPingService : IPing
    {
        public static int Number { get; set; }

        private readonly IHubContext<TestHub> testHub;

        public DefaultPingService(IHubContext<TestHub> testHub)
        {
            this.testHub = testHub;
        }

        public async Task<PingResponse> PingAsync(PingRequest request, CancellationToken cancellationToken = default)
        {
            Number++;
            
            //await testHub.Clients.Client().SendAsync(new SomeEvent
            //{
            //    Number = Number,
            //});
            
            return await RequestResponseHandler
                .New<PingRequest, PingResponse>(request, cancellationToken)
                .HandleAsync((request, response, cancellationToken) =>
                {
                    response.Content = request.Content;
                    return Task.CompletedTask;
                });
        }
    }
}
