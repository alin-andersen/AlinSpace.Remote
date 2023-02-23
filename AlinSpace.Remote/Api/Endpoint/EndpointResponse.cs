namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the endpoint response.
    /// </summary>
    public class EndpointResponse : Response
    {
        /// <summary>
        /// Gets or sets the endpoint name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the endpoint version.
        /// </summary>
        public Version ApplicationVersion { get; set; }

        /// <summary>
        /// Gets or sets the local timestamp.
        /// </summary>
        public DateTimeOffset? LocalTimestamp { get; set; }
    }
}