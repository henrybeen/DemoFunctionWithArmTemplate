using System.IO;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleFunction.Function;

[assembly: FunctionsStartup(typeof(Startup))]
namespace SimpleFunction.Function
{

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;

            var hostingEnvironment = services
                .BuildServiceProvider()
                .GetService<IHostingEnvironment>();

            var configurationBuilder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("secret.settings.json");
 
            var newConfiguration = configurationBuilder.Build();
            services.AddSingleton<IConfiguration>(newConfiguration);
        }
    }
}