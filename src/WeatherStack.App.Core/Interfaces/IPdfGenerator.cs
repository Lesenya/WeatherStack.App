
using WeatherStack.App.Core.Entities;

namespace WeatherStack.App.Core.Interfaces;
public interface IPdfGenerator
{
  Task SaveAsAsync(string name, Weather weather);
}
