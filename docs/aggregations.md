# Aggregations

More information in the [API Docs](https://docs.solcast.com.au/#eacaa7d2-66d7-474f-82a2-eed6c77fae60).

The `AggregationClient` has 2 available methods:

| Endpoint            | API Docs                                                                                                |
|---------------------|---------------------------------------------------------------------------------------------------------|
| `GetLiveAggregation` | [details](https://docs.solcast.com.au/#3b09628d-0f9d-4a01-aa53-9af460d6c66a){.md-button}                |
| `GetForecastAggregation` | [details](https://docs.solcast.com.au/#feeb0565-ac06-473a-8cd1-b1493c5bcabb){.md-button}          |

### Example

```csharp
using Solcast.Clients;

var aggregationClient = new AggregationClient();
var response = await _aggregationClient.GetForecastAggregations(
    collectionId: "country_total",
    aggregationId: "it_total",
    outputParameters: ["percentage", "pv_estimate"],
    format: "csv"
);

Console.WriteLine(response);
```

### API Parameters

#### Example Output (CSV):
```csv
PvEstimate,Percentage,PeriodEnd,Period
0.0,0.0,2024-09-13T04:30:00+00:00,PT30M
0.418,0.0,2024-09-13T05:00:00+00:00,PT30M
196.8466,0.6,2024-09-13T05:30:00+00:00,PT30M
...
```