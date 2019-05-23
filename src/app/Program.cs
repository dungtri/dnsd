using System.Threading.Tasks;

namespace App
{
    public class Program
    {
        private static readonly Logger Logger = new Logger();

        private const string AppName = "Cluster DNS Deamon";

        static async Task Main(string[] args)
        {
            Logger.Log($"{AppName} started.");

            var process = new Start(Logger);
            await process.GoAsync();

            Logger.Log($"{AppName} exited.");
        }
    }
}
