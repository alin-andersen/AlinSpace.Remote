namespace AlinSpace.Remote.Server
{
    public class DefaultHealthService : IHealth
    {
        public Task<HealthResponse> GetAsync(HealthRequest request, CancellationToken cancellationToken = default)
        {
            return RequestResponseHandler
               .New<HealthRequest, HealthResponse>(request, cancellationToken)
               .HandleAsync((request, response, cancellationToken) =>
               {
                   response.Result = HealthResult.Healthy;
                   return Task.CompletedTask;
               });
        }
    }
}
