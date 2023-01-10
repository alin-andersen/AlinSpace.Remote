using AlinSpace.Remote.Server;
using AlinSpace.Remote.Server.AspNetCore;
using AlinSpace.Remote.Test.Shared;
using Microsoft.AspNetCore.SignalR;

namespace AlinSpace.Remote.TestServer.AspNetCore
{
    public class DefaultPingService : IPing
    {
        private readonly IHubContext<TestHub> testHub;

        public DefaultPingService(IHubContext<TestHub> testHub)
        {
            this.testHub = testHub;
        }

        public async Task<PingResponse> PingAsync(PingRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                await testHub.Clients.All.SendAsync(new SomeEvent
                {
                    Number = 42,
                    Name = "HLAO",
                });
            }
            catch(Exception e)
            {

            }
            

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
