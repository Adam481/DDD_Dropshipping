using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDD_Dropshipping.Gateway.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            IWebHostBuilder builder = WebHost.CreateDefaultBuilder(args);

            //  Inject the IWebHostBuilder interface to get the applications scheme, url and port for ocelot
            builder.ConfigureServices(s =>
            {
                s.AddSingleton(builder);
            });

            // Add ocelot configuration file
            builder.ConfigureAppConfiguration((builderContext, config) =>
            {
                config.AddJsonFile("configuration.json");
            });

            // The rest is default
            return builder.UseStartup<Startup>()
                .Build();
        }
    }
}
