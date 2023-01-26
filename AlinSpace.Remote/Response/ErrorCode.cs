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

        RateLimited = 3,

        ServiceInMaintenance = 4,

        ResourceNotFound = 100,
        ResourceLocked = 101,

        AuthenticationRequired = 200,

        AuthorizationRequired = 300,

        WrongInput = 400,
        InvalidInput = 401,


    }
}