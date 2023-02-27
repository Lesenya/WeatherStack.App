namespace WeatherStack.App.Core.Entities;

public record Request
{
  public string Type { get; init; }
  public string Query { get; init; }
  public string Language { get; init; }
  public string Unit { get; init; }
}



