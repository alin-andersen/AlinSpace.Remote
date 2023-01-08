namespace AlinSpace.Remote.Server
{
    public class DefaultEndpointService : IEndpoint
    {
        public Task<EndpointResponse> GetAsync(EndpointRequest request, CancellationToken cancellationToken = default)
        {
            return RequestResponseHandler
                .New<EndpointRequest, EndpointResponse>(request, cancellationToken)
                .HandleAsync((request, response, cancellationToken) =>
                {
                    return Task.CompletedTask;
                });
        }
    }
}
