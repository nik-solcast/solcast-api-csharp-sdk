# Historic Data API

The **HistoricClient** in the Solcast SDK allows you to retrieve historical solar radiation and weather data. This data is available from 2007 to 7 days ago.

## Example Usage

To retrieve historical data, use the `HistoricClient` class.

```csharp
using Solcast.Clients;

var historicClient = new HistoricClient();
var response = await historicClient.GetRadiationAndWeather(-33.856784, 151.215297, "2022-01-01T00:00", duration: "P1D", format: "csv");

Console.WriteLine(response);
```

## API Parameters
- **latitude**: Latitude of the location in decimal degrees (north is positive).
- **longitude**: Longitude of the location in decimal degrees (east is positive).
- **start**: Start date of the requested period (ISO 8601 format).
end: Optional end date (ISO 8601 format).
- **duration**: Optional duration in ISO 8601 format.

For more information about the historic data API, visit the [Solcast API Docs](https://docs.solcast.com.au/#d2d99600-cd3b-4b33-96b3-02cabb25cd3d).

