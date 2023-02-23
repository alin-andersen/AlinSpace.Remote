namespace AlinSpace.Remote.Client.Console.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var connector = Connector.New(new Uri("http://localhost:5295"));

                var ping = connector.GetApi<IPing>();

                var t = ping.PingAsync(new PingRequest()
                {
                    Content = "Test",
                }).Result;

                System.Console.WriteLine(t.Content);
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            System.Console.ReadKey();
        }
    }
}