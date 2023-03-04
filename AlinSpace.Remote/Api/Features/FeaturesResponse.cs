namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the features response.
    /// </summary>
    public class FeaturesResponse : Response
    {
        /// <summary>
        /// Gets or sets the features.
        /// </summary>
        public IList<Feature> Features { get; set; }
    }
}