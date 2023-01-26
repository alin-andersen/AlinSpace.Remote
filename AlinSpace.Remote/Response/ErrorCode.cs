namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the response code.
    /// </summary>
    /// <remarks>
    /// 0 - 1000 reserved.
    /// </remarks>
    public enum ErrorCode
    {
        None = 0,
        Unknown = 1,
        Internal = 2,

        RateLimitation = 3,
        Maintenance = 4,

        NotFound = 100,

        Authentication = 200,

        Authorization = 300,
    }
}