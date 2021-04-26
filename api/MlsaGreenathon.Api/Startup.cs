using AzureMapsToolkit;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MlsaGreenathon.Api;

[assembly: FunctionsStartup(typeof(Startup))]
namespace MlsaGreenathon.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;

            builder.Services.AddSingleton<IAzureMapsServices>(new AzureMapsServices(configuration.GetConnectionString("AzureMaps")));
        }
    }
}