namespace AlinSpace.Remote.Server
{
    public class DefaultPingService : IPing
    {
        public Task<PingResponse> PingAsync(PingRequest request, CancellationToken cancellationToken = default)
        {
            return RequestResponseHandler
                .New<PingRequest, PingResponse>(request, cancellationToken)
                .HandleAsync((request, response, cancellationToken) =>
                {
                    response.Content = request.Content;
                    return Task.CompletedTask;
                });
        }
    }
}
