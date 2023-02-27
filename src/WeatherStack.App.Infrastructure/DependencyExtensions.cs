using Microsoft.Extensions.DependencyInjection;
using WeatherStack.App.Core.Interfaces;
using WeatherStack.App.Infrastructure.Clients;
using WeatherStack.App.Infrastructure.Services;

namespace WeatherStack.App.Infrastructure;
public static class DependencyExtensions
{
  public static void AddInfrastureLayerServices(this IServiceCollection services) 
  {
    services.AddHttpClient<IWeatherHttpClient, WeatherHttpClient>(client =>
    {
      client.BaseAddress = new Uri("http://api.weatherstack.com");
    });

    services.AddSingleton<IPdfGenerator, IronPdfGenerator>();
  }
      
}
