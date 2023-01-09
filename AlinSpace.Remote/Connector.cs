using Refit;

namespace AlinSpace.Remote
{
    /// <summary>
    /// Represents the connector.
    /// </summary>
    public class Connector
    {
        private readonly HttpClient httpClient;
        private readonly RefitSettings? refitSettings;

        public Connector(HttpClient httpClient, RefitSettings? refitSettings = null)
        {
            this.httpClient = httpClient;
            this.refitSettings = refitSettings;
        }

        public static Connector New(HttpClient httpClient, RefitSettings? refitSettings = null)
        {
            return new Connector(httpClient, refitSettings);
        }

        public Connector(Uri url, RefitSettings? refitSettings = null)
        {
            httpClient = new HttpClient
            {
                BaseAddress = url
            };

            this.refitSettings = refitSettings;
        }

        public static Connector New(Uri url, RefitSettings? refitSettings = null)
        {
            return new Connector(url, refitSettings);
        }

        public TApi GetApi<TApi>()
        {
            return RestService.For<TApi>(httpClient, refitSettings);
        }
    }
}