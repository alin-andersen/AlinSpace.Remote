namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the response code.
    /// </summary>
    /// <remarks>
    /// 0 - 1000 reserved.
    /// </remarks>
    public enum ResponseCode
    {
        Success = 0,
        Error = 1,
        ErrorInternal = 2,
        RateLimitation = 3,
        Maintenance = 4,
    }
}