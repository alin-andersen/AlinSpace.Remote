using Refit;

namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the health interface.
    /// </summary>
    public interface IHealth
    {
        /// <summary>
        /// Gets the health information asynchronously.
        /// </summary>
        /// <param name="request">Health request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Health response.</returns>
        [Get("/api/health")]
        Task<HealthResponse> GetAsync(HealthRequest request, CancellationToken cancellationToken = default);
    }
}
