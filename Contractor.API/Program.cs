namespace Contractor.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder
                .ConfigureServices()
                .ConfigurePipeline();

            // W œrodowisku developerskim - reinicjacja bazy danych
            await app.ResetDatabaseAsync();

            app.Run();
        }
    }
}