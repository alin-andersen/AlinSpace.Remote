using AlinSpace.Remote.Server;

namespace AlinSpace.Remote.TestServer.AspNetCore
{
    public class PingService : IPing
    {
        public Task<PingResponse> PingAsync(PingRequest request, CancellationToken cancellationToken = default)
        {
            return RequestResponseHandler
                .New<PingRequest, PingResponse>(request, cancellationToken)
                .HandleAsync(async (request, response, cancellationToken) =>
                {


                });
        }
    }
}
