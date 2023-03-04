namespace AlinSpace.Remote
{
    public static class RemoteExtensions
    {
        public static void ThrowIfError(this Response response)
        {
            if (response.IsError)
            {
                throw new RemoteException(response);
            }
        }
    }
}
