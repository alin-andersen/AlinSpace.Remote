namespace AlinSpace.Remote.Server
{
    /// <summary>
    /// Represents the default implementation for <see cref="IEndpoint"/>.
    /// </summary>
    public class EndpointService : IEndpoint
    {
        private readonly Func<EndpointRequest, EndpointResponse, CancellationToken, Task> function;

        /// <summary>
        /// Constructor.
        /// </summary>
        public EndpointService(Func<EndpointRequest, EndpointResponse, CancellationToken, Task> function = null)
        {
            this.function = function ?? new Func<EndpointRequest, EndpointResponse, CancellationToken, Task>((request, response, cancellationToken) 
                => Task.CompletedTask);
        }

        public Task<EndpointResponse> GetAsync(EndpointRequest request, CancellationToken cancellationToken = default)
        {
            return RequestResponseHandler
                .New<EndpointRequest, EndpointResponse>(request, cancellationToken: cancellationToken)
                .HandleAsync(async (request, response, cancellationToken) 
                    => await function(request, response, cancellationToken));
        }
    }
}
