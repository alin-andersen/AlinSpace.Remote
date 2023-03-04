namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the page request.
    /// </summary>
    public class PageRequest : Request
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public Page Page { get; set; }
    }

    /// <summary>
    /// Represents the page request.
    /// </summary>
    /// <typeparam name="T">Type of the value.</typeparam>
    public class PageRequest<T> : Request<T>
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public Page Page { get; set; }
    }
}
