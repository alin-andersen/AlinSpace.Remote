using Refit;

namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the endpoint interface.
    /// </summary>
    public interface IEndpoint
    {
        /// <summary>
        /// Gets the endpoint information asynchronously.
        /// </summary>
        /// <param name="request">Endpoint request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Endpoint response.</returns>
        [Get("/api/endpoint")]
        Task<EndpointResponse> GetAsync(EndpointRequest request, CancellationToken cancellationToken = default);
    }
}
