namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the endpoint response.
    /// </summary>
    public class EndpointResponse : Response
    {
        /// <summary>
        /// Gets or sets the application name.
        /// </summary>
        public string? ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets the version of the application.
        /// </summary>
        public Version? ApplicationVersion { get; set; }

        /// <summary>
        /// Gets or sets the local time of the endpoint.
        /// </summary>
        public DateTimeOffset? EndpointLocalTime { get; set; }
    }
}