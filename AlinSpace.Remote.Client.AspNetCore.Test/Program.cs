using System.Net.NetworkInformation;

namespace AlinSpace.Remote.Client.AspNetCore.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var client = HttpClientFactory.Create(new Uri("http://localhost:5295"), ignoreCertificates: true);

                var connector = RemoteApi.New(client);

                var ping = connector.GetApi<IPing>();

                var t = ping.PingAsync(new PingRequest()
                {
                    Content = "Test",
                }).Result;

                System.Console.WriteLine(t.Content);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            System.Console.ReadKey();
        }
    }
}