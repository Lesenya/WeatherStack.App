using System.Text;
using IronPdf;
using WeatherStack.App.Core.Entities;
using WeatherStack.App.Core.Interfaces;

namespace WeatherStack.App.Infrastructure.Services;
public class IronPdfGenerator : IPdfGenerator
{
  public async Task SaveAsAsync(string name, Weather weather)
  {
    var renderer = new ChromePdfRenderer();
    var html = GetLocationHtml(weather.Location) + GetCurrentWeatherHtml(weather.Current);
    var pdf =  await renderer.RenderHtmlAsPdfAsync(html);

    pdf.SaveAs(name);
  }

  private string GetCurrentWeatherHtml(Current current) 
  {
    var stringBuilder = new StringBuilder();
    stringBuilder.Append("<h3>Current Weather</h3>");
    var weatherDescriptions = $"<span>{string.Join(",", current.WeatherDescriptions)}</span>";
    var imageStringBuilder = new StringBuilder();
    current.WeatherIcons.ForEach(icon => 
    {
      imageStringBuilder.Append($"<span><img src='{icon}'></span>");
    });

    stringBuilder.Append($"<p>{imageStringBuilder} {weatherDescriptions}</p>");
    var props = current.GetType().GetProperties().Where(p => !(p.Name.Equals("WeatherIcons") || p.Name.Equals("WeatherDescriptions")));

    foreach (var prop in props)
    {
      var val = current.GetType()?.GetProperty(prop.Name)?.GetValue(current) ?? "";
      stringBuilder.Append($"<p><strong>{prop.Name}</strong>: {val}</p>");
    }

    return stringBuilder.ToString();
  }

  private string GetLocationHtml(Location location)
  {
    var stringBuilder = new StringBuilder();
    var props = location.GetType().GetProperties();
    
    foreach (var prop in props)
    {
      var val = location.GetType()?.GetProperty(prop.Name)?.GetValue(location) ?? "";
      stringBuilder.Append($"<p><strong>{prop.Name}</strong>: {val}</p>");
    }

    return stringBuilder.ToString();
  }
}
