using Refit;

namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the features service interface.
    /// </summary>
    public interface IFeatures
    {
        /// <summary>
        /// Gets the features asynchronously.
        /// </summary>
        /// <param name="request">Features request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Features response.</returns>
        [Get("/api/features")]
        Task<FeaturesResponse> GetFeaturesAsync(FeaturesRequest request, CancellationToken cancellationToken = default);
    }
}
