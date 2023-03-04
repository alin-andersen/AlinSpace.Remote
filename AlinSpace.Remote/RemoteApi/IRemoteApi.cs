namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the remote API.
    /// </summary>
    /// <remarks>
    /// Used as a wrapper around Refit.
    /// </remarks>
    public interface IRemoteApi
    {
        /// <summary>
        /// Gets the API.
        /// </summary>
        /// <typeparam name="TApi">Type of API.</typeparam>
        /// <returns>API.</returns>
        TApi GetApi<TApi>();
    }
}
