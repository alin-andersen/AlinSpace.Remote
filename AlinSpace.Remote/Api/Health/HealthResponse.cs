namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the health response.
    /// </summary>
    public class HealthResponse : Response
    {
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <remarks>
        /// If the health of the features are set,
        /// this is the worst state contained in the features list.
        /// </remarks>
        public HealthState State { get; set; }

        /// <summary>
        /// Gets or sets the features.
        /// </summary>
        public IList<HealthOfFeature> HealthOfFeatures { get; set; }
    }
}