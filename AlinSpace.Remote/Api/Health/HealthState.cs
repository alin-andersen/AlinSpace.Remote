namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the health state.
    /// </summary>
    public enum HealthState
    {
        /// <summary>
        /// System is healthy and is working as expected.
        /// </summary>
        Healthy = 0,

        /// <summary>
        /// System is unhealthy and may not work as expected.
        /// </summary>
        Unhealthy = 1,
    }
}
