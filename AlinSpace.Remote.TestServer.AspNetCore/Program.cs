namespace AlinSpace.Remote.TestServer.AspNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IPing, PingService>();

            var app = builder.Build();

            app.MapS

            app.Run();
        }
    }
}