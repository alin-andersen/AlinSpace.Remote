using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace AlinSpace.Remote.Server.AspNetCore
{
    /// <summary>
    /// Represents extensions for <see cref="IWebHostBuilder"/>.
    /// </summary>
    public static class WebHostBuilderExtensions
    {
        /// <summary>
        /// Use HTTP only.
        /// </summary>
        /// <param name="builder">Builder.</param>
        /// <param name="address">Address.</param>
        /// <returns>Builder.</returns>
        public static IWebHostBuilder UseHttpOnly(this IWebHostBuilder builder, IPAddress address = null)
        {
            return builder.UseKestrel(options => options.Listen(address ?? IPAddress.Loopback, 80));
        }
    }
}
