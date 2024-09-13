# Forecast Data API

The **ForecastClient** in the Solcast SDK allows you to retrieve solar radiation and weather forecasts for up to 14 days ahead. The forecasts are based on satellite observations and numerical weather models.

## Example Usage

To retrieve forecast data, use the `ForecastClient` class.

```csharp
using Solcast.Clients;

var forecastClient = new ForecastClient();
var response = await forecastClient.GetForecast(-33.856784, 151.215297, new[] { "air_temp", "dni", "ghi" });

Console.WriteLine(response);
```

## API Parameters
- **latitude**: Latitude of the location in decimal degrees (north is positive).
- **longitude**: Longitude of the location in decimal degrees (east is positive).
- **output_parameters**: An array of parameters to return, such as `dni`, `ghi`, `air_temp`.

For more information about the forecast data API, visit the [Solcast API Docs](https://docs.solcast.com.au/#80627973-4183-4ebc-8a3d-1b2324fd1ed1).

