namespace AlinSpace.Remote.Server
{
    /// <summary>
    /// Represents the default implementation for <see cref="IPing"/>.
    /// </summary>
    public class PingService : IPing
    {
        private readonly Func<PingRequest, PingResponse, CancellationToken, Task> function;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="function">Ping function.</param>
        public PingService(Func<PingRequest, PingResponse, CancellationToken, Task> function = null)
        {
            this.function = function ?? new Func<PingRequest, PingResponse, CancellationToken, Task>((request, response, cancellationToken) =>
            {
                response.Content = request.Content;
                return Task.CompletedTask;
            });
        }

        public Task<PingResponse> PingAsync(PingRequest request, CancellationToken cancellationToken = default)
        {
            return RequestResponseHandler
                .New<PingRequest, PingResponse>(request, cancellationToken: cancellationToken)
                .HandleAsync((request, response, cancellationToken)
                    => function(request, response, cancellationToken));
        }
    }
}
