namespace AlinSpace.Remote
{
    public class RemoteException : Exception
    {
        public ErrorCode ErrorCode { get; }

        public string Error { get; }

        public string RemoteExceptionMessage { get; }

        public string RemoteExceptionStacktrace { get; }

        public RemoteException(Response response)
        {
            ErrorCode = response.ErrorCode;
            Error = response.Error;
            RemoteExceptionMessage = response.ExceptionMessage;
            RemoteExceptionStacktrace = response.ExceptionStacktrace;
        }
    }
}
