using System.Net.Http.Json;
using WeatherStack.App.Core.Entities;
using WeatherStack.App.Core.Interfaces;

namespace WeatherStack.App.Infrastructure.Clients;
public class WeatherHttpClient : IWeatherHttpClient
{
  private readonly HttpClient _httpClient;

  public WeatherHttpClient(HttpClient httpClient)
  {
    _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
  }

  public async Task<Weather> GetWeatherDataAsync(string cityName, string accessKey)
  {
    var items = await _httpClient.GetFromJsonAsync<Weather>($"current?access_key={accessKey}&query={cityName}&units=f");
    return items ?? new();
  }
}
