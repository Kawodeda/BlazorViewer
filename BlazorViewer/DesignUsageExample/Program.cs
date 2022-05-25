using Aurigma.Design;
using Aurigma.Design.Appearance;
using Aurigma.Design.Appearance.Color;
using Aurigma.Design.Content;
using Aurigma.Design.Content.Controls;
using Aurigma.Design.Math;
using Google.Protobuf;
using ApiClient;

namespace DesignUsageExample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IDesignsApiClient client = new DesignsApiClient(
                "https://localhost:7091/", 
                new HttpClient());

            try
            {
                Console.WriteLine("Recieving designs...");

                var designs = await client.ListDesignsAsync();

                Console.WriteLine("All designs:");
                foreach (var d in designs)
                {
                    Console.WriteLine(d.ToJson());
                }

                Console.Write("\nName: ");
                string name = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("\nRecieving data...");

                var designContent = await client.GetDesignContentAsync(name);
                Design design = Design.Parser.ParseFrom(designContent.Stream);

                Console.WriteLine($"\nContent:\n{design.ToString()}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"\n{ex.Message}");
            }
        }
    }
}
