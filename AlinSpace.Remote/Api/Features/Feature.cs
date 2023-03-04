namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the feature.
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public Version Version { get; set; }

        /// <summary>
        /// Gets or sets the features.
        /// </summary>
        public IList<Feature> Features { get; set; } 
    }
}
