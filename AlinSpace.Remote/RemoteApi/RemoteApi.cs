using Refit;

namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the default implementation for <see cref="IRemoteApi"/>.
    /// </summary>
    public class RemoteApi : IRemoteApi
    {
        protected HttpClient HttpClient { get; }

        public RemoteApi(HttpClient httpClient = null)
        {
            HttpClient = httpClient ?? HttpClientFactory.CreateWithDefaultPolicy();
        }

        public static IRemoteApi New(HttpClient httpClient = null)
        {
            return new RemoteApi(httpClient);
        }

        public virtual TApi GetApi<TApi>()
        {
            return RestService.For<TApi>(HttpClient);
        }
    }
}
