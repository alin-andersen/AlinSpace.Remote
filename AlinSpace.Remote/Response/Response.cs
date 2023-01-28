using System.Text.Json.Serialization;

namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the response.
    /// </summary>
    public class Response
    {
        #region ErrorCode

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public ErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Gets the is success flag.
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess => ErrorCode == ErrorCode.None;

        /// <summary>
        /// Gets the is error flag.
        /// </summary>
        [JsonIgnore]
        public bool IsError => !IsSuccess;

        #endregion

        /// <summary>
        /// Gets or sets the response text message.
        /// </summary>
        public string ResponseTextMessage { get; set; }

        /// <summary>
        /// Gets or sets the correlation ID.
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        public string Metadata { get; set; }

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
        [JsonIgnore]
        public TimeSpan? ExecutionDuration => ResponseTimestamp - RequestTimestamp;

        #endregion

        #region Exception

        /// <summary>
        /// Gets or sets the exception message.
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Gets or sets the exception stacktrace.
        /// </summary>
        public string ExceptionStacktrace { get; set; }

        #endregion
    }

    /// <summary>
    /// Represents the response.
    /// </summary>
    /// <typeparam name="T">Type of the item.</typeparam>
    public class Response<T> : Response
    {
       public T Item { get; set; }
    }
}
