namespace AlinSpace.Remote.Server.AspNetCore.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IPing, DefaultPingService2>();
            
            var app = builder.Build();

            app.AlinSpaceRemoteMapService<IPing>();

            app.Run();
        }
    }
}