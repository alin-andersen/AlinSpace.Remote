namespace AlinSpace.Remote.Server
{
    /// <summary>
    /// Represents the default implementation for <see cref="IHealth"/>.
    /// </summary>
    public class HealthService : IHealth
    {
        private readonly Func<HealthRequest, HealthResponse, CancellationToken, Task> function;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="healthChecker">Health checker.</param>
        public HealthService(Func<HealthRequest, HealthResponse, CancellationToken, Task> function = null)
        {
            this.function = function ?? new Func<HealthRequest, HealthResponse, CancellationToken, Task>((request, response, cancellationToken) =>
            {
                response.State = HealthState.Healthy;
                return Task.CompletedTask;
            });
        }

        public Task<HealthResponse> GetAsync(HealthRequest request, CancellationToken cancellationToken = default)
        {
            return RequestResponseHandler
               .New<HealthRequest, HealthResponse>(request, cancellationToken: cancellationToken)
               .HandleAsync(async (request, response, cancellationToken)
                    => await function(request, response, cancellationToken));
        }
    }
}
