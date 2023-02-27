using System.Text.Json.Serialization;

namespace WeatherStack.App.Core.Entities;
public record Location
{
  public string Name { get; init; }
  public string Country { get; init; }
  public string Region { get; init; }
  public string Lat { get; init; }
  public string Lon { get; init; }

  [JsonPropertyName("timezone_id")]
  public string TimezoneId { get; init; }

  public string Localtime { get; init; }

  [JsonPropertyName("localtime_epoch")]
  public int LocaltimeEpoch { get; init; }

  [JsonPropertyName("utc_offset")]
  public string UtcOffset { get; init; }
}



