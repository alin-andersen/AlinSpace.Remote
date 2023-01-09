namespace AlinSpace.Remote.TestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connector = Connector.New(new Uri("http://localhost:5086/"));

            var ping = connector.GetApi<IPing>();

            var response = ping.PingAsync(new PingRequest()).Result;
        }
    }
}