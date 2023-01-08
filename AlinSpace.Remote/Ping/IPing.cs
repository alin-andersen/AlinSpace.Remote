using Refit;

namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the ping service.
    /// </summary>
    public interface IPing
    {
        /// <summary>
        /// Performs the ping operation asynchronously.
        /// </summary>
        /// <param name="request">Ping request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Ping response.</returns>
        [Post("/api/ping")]
        Task<PingResponse> PingAsync(PingRequest request, CancellationToken cancellationToken = default);
    }
}
