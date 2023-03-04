namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the health of a feature
    /// </summary>
    public class HealthOfFeature
    {
        /// <summary>
        /// Gets or sets the feature name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the health state.
        /// </summary>
        public HealthState State { get; set; }

        /// <summary>
        /// Gets or sets the health of the features.
        /// </summary>
        public IList<HealthOfFeature> HealthOfFeatures { get; set; }
    }
}
