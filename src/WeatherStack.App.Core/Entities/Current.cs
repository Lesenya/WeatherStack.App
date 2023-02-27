using System.Text.Json.Serialization;

namespace WeatherStack.App.Core.Entities;

public record Current
{
  [JsonPropertyName("observation_time")]
  public string ObservationTime { get; init; }

  public int Temperature { get; init; }

  [JsonPropertyName("weather_code")]
  public int WeatherCode { get; init; }

  [JsonPropertyName("weather_icons")]
  public List<string> WeatherIcons { get; init; }

  [JsonPropertyName("weather_descriptions")]
  public List<string> WeatherDescriptions { get; init; }

  [JsonPropertyName("wind_speed")]
  public int WindSpeed { get; init; }

  [JsonPropertyName("wind_degree")]
  public int WindDegree { get; init; }

  [JsonPropertyName("wind_dir")]
  public string WindDir { get; init; }

  public int Pressure { get; init; }

  public int Precip { get; init; }

  public int Humidity { get; init; }

  public int CloudCover { get; init; }

  public int FeelsLike { get; init; }

  [JsonPropertyName("uv_index")]
  public int UvIndex { get; init; }

  public int Visibility { get; init; }
}



