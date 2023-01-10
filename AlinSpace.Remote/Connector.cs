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

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">HTTP client.</param>
        /// <param name="refitSettings">Refit settings.</param>
        public Connector(HttpClient httpClient, RefitSettings refitSettings = null)
        {
            this.httpClient = httpClient;
            this.refitSettings = refitSettings;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">HTTP client.</param>
        /// <param name="refitSettings">Refit settings.</param>
        public static Connector New(HttpClient httpClient, RefitSettings refitSettings = null)
        {
            return new Connector(httpClient, refitSettings);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="refitSettings">Refit settings.</param>
        public Connector(Uri url, RefitSettings refitSettings = null)
        {
            httpClient = new HttpClient
            {
                BaseAddress = url
            };

            this.refitSettings = refitSettings;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="refitSettings">Refit settings.</param>
        public static Connector New(Uri url, RefitSettings refitSettings = null)
        {
            return new Connector(url, refitSettings);
        }

        /// <summary>
        /// Gets the API.
        /// </summary>
        /// <typeparam name="TApi">Type of API.</typeparam>
        /// <returns>API.</returns>
        public TApi GetApi<TApi>()
        {
            return RestService.For<TApi>(httpClient, refitSettings);
        }
    }
}