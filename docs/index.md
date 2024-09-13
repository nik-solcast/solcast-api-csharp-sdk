# Welcome to the Solcast C# SDK

The **Solcast C# SDK** allows you to access the Solcast API to retrieve live and forecasted solar radiation and weather data. It provides simple client classes to interact with the API and retrieve data in an easy-to-use format.

## Install

To install the SDK, add the package to your project using the following command:

```bash
dotnet add package Solcast
```

Alternatively, you can clone the SDK and build it locally:

```bash
git clone https://github.com/Solcast/solcast-api-csharp-sdk.git
cd solcast-api-csharp-sdk
dotnet build
```

## Usage

To use the SDK, you need to set your Solcast API key as an environment variable:

```bash
$env:SOLCAST_API_KEY = "{your_api_key}"
```

Example: Retrieving Live Radiation and Weather Data
```csharp
using Solcast.Clients;

var liveClient = new LiveClient();
var response = await liveClient.GetRadiationAndWeather(-33.856784, 151.215297, new[] { "air_temp", "dni", "ghi" });
Console.WriteLine(response);
```

Example: Retrieving Forecast Data
```csharp
using Solcast.Clients;

var forecastClient = new ForecastClient();
var response = await forecastClient.GetForecast(-33.856784, 151.215297, new[] { "air_temp", "dni", "ghi" });
Console.WriteLine(response);
```

Example: Retrieving Historic Radiation and Weather Data
```csharp
using Solcast.Clients;

var historicClient = new HistoricClient();
var response = await historicClient.GetRadiationAndWeather(-33.856784, 151.215297, "2022-01-01T00:00", duration: "P1D");

Console.WriteLine(response);
```

For more detailed documentation, visit the following pages:

[Live Data](live.md)
[Historic Data](historic.md)
[Forecast Data](forecast.md)
[TMY Data](tmy.md)
[Grid Aggregations](aggregations.md)
[PV Power Sites](pv_power_sites.md)


## API Documentation
For more detailed information about the Solcast API, please visit the official API documentation.

