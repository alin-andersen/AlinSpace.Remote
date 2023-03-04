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
        Maintenance = 3,
        RateLimitReached = 4,

        ResourceNotFound = 100,
        ResourceExists = 101,
        ResourceLocked = 102,
        ResourceExpired = 103,

        AuthenticationRequired = 200,
        AuthenticationExpired = 201,

        AuthorizationRequired = 300,
        AuthorizationExpired = 301,

        WrongInput = 400,
        InvalidInput = 401,


    }
}