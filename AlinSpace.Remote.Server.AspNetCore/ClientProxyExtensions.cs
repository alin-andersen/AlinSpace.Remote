using Microsoft.AspNetCore.SignalR;
using System.Text.Json;

namespace AlinSpace.Remote.Server.AspNetCore
{
    public static class ClientProxyExtensions
    {
        public static async Task SendEventAsync<T>(this IClientProxy clientProxy, T @object)
        {
            var @event = new Event
            {
                Type = typeof(T).FullName,
                Data = JsonSerializer.Serialize(@object),
            };

            await clientProxy.SendAsync(nameof(Event), @event.Serialize());
        }
    }
}
