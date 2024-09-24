using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class HistoricForecastPvPowerResponse
{
    [JsonProperty("historic_forecasts")]
    public List<Dictionary<string, object>> HistoricForecasts { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
