namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the ping request.
    /// </summary>
    public class PingRequest : Request
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string Content { get; set; }
    }
}