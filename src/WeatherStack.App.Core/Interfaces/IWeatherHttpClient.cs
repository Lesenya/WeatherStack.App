using WeatherStack.App.Core.Entities;

namespace WeatherStack.App.Core.Interfaces;
public interface IWeatherHttpClient
{
  Task<Weather> GetWeatherDataAsync(string cityName, string accessKey);
}
