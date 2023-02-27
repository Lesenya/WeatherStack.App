using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherStack.App.Core.Interfaces;
using WeatherStack.App.Infrastructure;

internal class Program
{
  private static async Task Main(string[] args)
  {
    using var host = Host.CreateDefaultBuilder(args)
      .ConfigureAppConfiguration((builderContext, config) => 
      {
        config.AddJsonFile("appsettings.json", optional: false);
      })
      .ConfigureServices(services =>
      {
        services.AddInfrastureLayerServices();
      }).Build();

    // Create a scope so that scoped services can be resolved as well
    using var serviceScope = host.Services.CreateScope();
    var provider = serviceScope.ServiceProvider;

    // These would typically be resolved through constructor injection
    var httpClient = provider.GetRequiredService<IWeatherHttpClient>();
    var pdfGenerator = provider.GetRequiredService<IPdfGenerator>();
    var configuration = provider.GetRequiredService<IConfiguration>();
    var exitCode = "Y";

    do
    {
      Console.WriteLine("Enter name of the city:");
      var cityName = Console.ReadLine();

      if (!string.IsNullOrEmpty(cityName))
      {
        var weather = await httpClient.GetWeatherDataAsync(cityName, configuration["AccessKey"]);
        var fileName = $"weather_{cityName}_{DateTime.UtcNow.ToString("HHmmss")}.pdf";

        await pdfGenerator.SaveAsAsync(fileName, weather);
      }

      Console.WriteLine("Type Y to continue or any key to exit:");
      exitCode = Console.ReadLine();

    } while (exitCode == "Y");


  }

}
