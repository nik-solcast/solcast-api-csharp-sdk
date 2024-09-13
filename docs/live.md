# Live Data API

The **LiveClient** in the Solcast SDK allows you to retrieve live solar radiation and weather data. The data is derived from satellite observations and numerical weather models.

## Example Usage

To retrieve live data, use the `LiveClient` class.

```csharp
using Solcast.Clients;

var liveClient = new LiveClient();
var response = await liveClient.GetRadiationAndWeather(-33.856784, 151.215297, new[] { "air_temp", "dni", "ghi" });

Console.WriteLine(response);
```

## API Parameters
- **latitude**: Latitude of the location in decimal degrees (north is positive).
- **longitude**: Longitude of the location in decimal degrees (east is positive).
- **output_parameters**: An array of parameters to return, such as `dni`, `ghi`, `air_temp`.

---
For more information about the live data API, visit the [Solcast API Docs](https://docs.solcast.com.au/?#a20936b9-a41c-4ff3-b169-5ad8c5f4960b).
