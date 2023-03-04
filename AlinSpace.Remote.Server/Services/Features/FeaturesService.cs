namespace AlinSpace.Remote.Server
{
    /// <summary>
    /// Represents the default implementation for <see cref="IFeatures"/>.
    /// </summary>
    public class FeaturesService : IFeatures
    {
        private readonly Func<FeaturesRequest, FeaturesResponse, CancellationToken, Task> function;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="healthChecker">Health checker.</param>
        public FeaturesService(Func<FeaturesRequest, FeaturesResponse, CancellationToken, Task> function = null)
        {
            this.function = function ?? new Func<FeaturesRequest, FeaturesResponse, CancellationToken, Task>((response, request, cancellationToken) =>
            {
                return Task.CompletedTask;
            });
        }

        public Task<FeaturesResponse> GetFeaturesAsync(FeaturesRequest request, CancellationToken cancellationToken = default)
        {
            return RequestResponseHandler
               .New<FeaturesRequest, FeaturesResponse>(request, cancellationToken: cancellationToken)
               .HandleAsync(async (request, response, cancellationToken)
                    => await function(request, response, cancellationToken));
        }
    }
}
