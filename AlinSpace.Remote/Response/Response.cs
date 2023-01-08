namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the response.
    /// </summary>
    public class Response
    {
        #region ResponseCode

        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        public ResponseCode ResponseCode { get; set; }

        /// <summary>
        /// Gets the is success flag.
        /// </summary>
        public bool IsSuccess => ResponseCode == ResponseCode.Success;

        /// <summary>
        /// Gets the is error flag.
        /// </summary>
        public bool IsError => ResponseCode == ResponseCode.Error;

        /// <summary>
        /// Gets the is rate limited flag.
        /// </summary>
        public bool IsRateLimited => ResponseCode == ResponseCode.RateLimitation;

        /// <summary>
        /// Gets the is maintained flag.
        /// </summary>
        public bool IsMaintained => ResponseCode == ResponseCode.Maintenance;

        /// <summary>
        /// Gets the is internal error flag.
        /// </summary>
        public bool IsInternalError => ResponseCode == ResponseCode.ErrorInternal;

        #endregion

        /// <summary>
        /// Gets or sets the response text message.
        /// </summary>
        public string? ResponseTextMessage { get; set; }

        /// <summary>
        /// Gets or sets the correlation ID.
        /// </summary>
        public string? CorrelationId { get; set; }

        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        public string? Metadata { get; set; }

        #region Timestamps

        /// <summary>
        /// Gets or sets the request timestamp.
        /// </summary>
        public DateTimeOffset? RequestTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the response timestamp.
        /// </summary>
        public DateTimeOffset? ResponseTimestamp { get; set; }

        /// <summary>
        /// Gets the execution duration.
        /// </summary>
        public TimeSpan? ExecutionDuration => ResponseTimestamp - RequestTimestamp;

        #endregion

        #region Exception

        /// <summary>
        /// Gets or sets the exception message.
        /// </summary>
        public string? ExceptionMessage { get; set; }

        /// <summary>
        /// Gets or sets the exception stacktrace.
        /// </summary>
        public string? ExceptionStacktrace { get; set; }

        #endregion
    }

    /// <summary>
    /// Represents the response.
    /// </summary>
    /// <typeparam name="T">Type of the item.</typeparam>
    public class Response<T> : Response
    {
       public T? Item { get; set; }
    }
}
