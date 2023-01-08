using Refit;

namespace AlinSpace.Remote.TestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pingApi = RestService.For<IPing>("http://localhost:5086/");

            var response = pingApi.PingAsync(new PingRequest()).Result;


        }
    }
}