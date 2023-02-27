using WeatherStack.App.Core.Entities;

namespace WeatherStack.App.Core.Entities;
public record Weather
{
  public Request Request { get; init; }
  public Location Location { get; init; }
  public Current Current { get; init; }
}
