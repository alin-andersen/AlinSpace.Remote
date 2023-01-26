namespace AlinSpace.Remote.Server
{
    /// <summary>
    /// Represents the response handler.
    /// </summary>
    /// <typeparam name="TResponse">Type of response.</typeparam>
    public class RequestResponseHandler<TRequest, TResponse>
        where TRequest : Request
        where TResponse : Response, new()
    {
        /// <summary>
        /// Gets the request.
        /// </summary>
        public TRequest Request { get; }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        public TResponse Response { get; set; } = new TResponse();

        /// <summary>
        /// Gets the exception handler.
        /// </summary>
        public Func<TRequest, TResponse, Exception, Task> ExceptionHandler { get; set; }

        /// <summary>
        /// Gets or sets the cancellation token.
        /// </summary>
        public CancellationToken CancellationToken { get; set; }

        /// <summary>
        /// Gets or sets the flag indicating whether or not the exception details shall be included in the response.
        /// </summary>
        public bool IncludeExceptionDetailsInResponse { get; set; }

        /// <summary>
        /// Gets or sets the flag indicating wether or not the timestamps shall be included.
        /// </summary>
        public bool IncludeTimestamps { get; set; } = true;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public RequestResponseHandler(TRequest request, Func<TRequest, TResponse, Exception, Task> exceptionHandler = null, CancellationToken cancellationToken = default)
        {
            Request = request;
            Response.SetCorrelationIdFromRequest(request);
            ExceptionHandler = exceptionHandler;
        }

        /// <summary>
        /// Handles the request/response pair asynchronously.
        /// </summary>
        /// <param name="func">Delegate to be executed.</param>
        /// <returns>Response.</returns>
        public async Task<TResponse> HandleAsync(Func<TRequest, TResponse, CancellationToken, Task> func)
        {
            if (IncludeTimestamps)
            {
                Response.MarkBeginOfInvocation();
            }

            try
            {
                await func(Request, Response, CancellationToken);
            }
            catch(Exception e)
            {
                if (IncludeExceptionDetailsInResponse)
                {
                    Response.ExceptionMessage = e.Message;
                    Response.ExceptionStacktrace = e.StackTrace;
                }

                if (ExceptionHandler == null)
                {
                    Response.ErrorCode = ErrorCode.Unknown;
                }
                else
                {
                    try
                    {
                        await ExceptionHandler.Invoke(Request, Response, e);
                    }
                    catch
                    {
                        Response.ErrorCode = ErrorCode.Internal;
                    }
                }
            }

            if (IncludeTimestamps)
            {
                Response.MarkEndOfInvocation();
            }

            return Response;
        }
    }

    public class RequestResponseHandler
    {
        public static RequestResponseHandler<TRequest, TResponse> New<TRequest, TResponse>(TRequest request, Func<TRequest, TResponse, Exception, Task> exceptionHandler = null, CancellationToken cancellationToken = default)
            where TRequest : Request
            where TResponse : Response, new()
        {
            return new RequestResponseHandler<TRequest, TResponse>(request, exceptionHandler, cancellationToken);
        }
    }
}
