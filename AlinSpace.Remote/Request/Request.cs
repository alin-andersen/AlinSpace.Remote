namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the request.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Gets or sets the correlation ID.
        /// </summary>
        public string? CorrelationId { get; set; }

        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        public string? Metadata { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string? AccessToken { get; set; }
    }

    /// <summary>
    /// Represents the request.
    /// </summary>
    /// <typeparam name="T">Type of the value.</typeparam>
    public class Request<T> : Request
    {
        public T? Value { get; set; }
    }

    /// <summary>
    /// Represents the page request.
    /// </summary>
    public class PageRequest : Request
    {
        public Page? Page { get; set; }
    }

    /// <summary>
    /// Represents the page request.
    /// </summary>
    /// <typeparam name="T">Type of the value.</typeparam>
    public class PageRequest<T> : Request<T>
    {
        public Page? Page { get; set; }
    }
}
