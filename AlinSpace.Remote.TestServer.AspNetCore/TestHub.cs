using Microsoft.AspNetCore.SignalR;

namespace AlinSpace.Remote.TestServer.AspNetCore
{
    public class TestHub : Hub
    {
        public async Task SendEvent(string @event) => await Clients.All.SendAsync("Event", @event);
    }
}
