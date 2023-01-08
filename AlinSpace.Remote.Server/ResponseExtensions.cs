namespace AlinSpace.Remote.Server
{
    /// <summary>
    /// Represents the extensions for <see cref="Response"/>.
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// Marks the begin of the invocation.
        /// </summary>
        /// <param name="response">Response.</param>
        /// <param name="utc">Use UTC.</param>
        /// <returns>Response.</returns>
        public static Response MarkBeginOfInvocation(this Response response, bool utc = true)
        {
            response.RequestTimestamp = utc ? DateTimeOffset.UtcNow : DateTimeOffset.Now;
            return response;
        }

        /// <summary>
        /// Marks the end of the invocation.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="utc"></param>
        /// <returns>Response.</returns>
        public static Response MarkEndOfInvocation(this Response response, bool utc = true)
        {
            response.ResponseTimestamp = utc ? DateTimeOffset.UtcNow : DateTimeOffset.Now;
            return response;
        }

        /// <summary>
        /// Sets the correlation ID from the request.
        /// </summary>
        /// <param name="response">Response.</param>
        /// <param name="request">Request.</param>
        /// <returns>Response.</returns>
        public static Response SetCorrelationIdFromRequest(this Response response, Request request)
        {
            response.CorrelationId = request.CorrelationId;
            return response;
        }
    }
}
