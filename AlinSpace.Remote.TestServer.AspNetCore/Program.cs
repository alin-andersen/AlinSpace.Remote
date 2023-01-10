using AlinSpace.Remote.Server;
using AlinSpace.Remote.Server.AspNetCore;
using AlinSpace.Remote.Test.Shared;

namespace AlinSpace.Remote.TestServer.AspNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            builder.Services.AddScoped<IPing, DefaultPingService>();
            builder.Services.AddScoped<IHealth, DefaultHealthService>();
            builder.Services.AddScoped<IEndpoint, DefaultEndpointService>();
            builder.Services.AddScoped<ISimpleFile, SimpleFile>();

            builder.Services.AddSignalR(x =>
            {
                
            });

            var app = builder.Build();

            app.MapService<IPing>();
            app.MapService<IHealth>();
            app.MapService<IEndpoint>();
            app.MapService<ISimpleFile>();

            app.MapHub<TestHub>("/hub");

            app.Map("/", () => "HelloWorld");

            app.Run();
        }
    }
}