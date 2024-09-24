using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class ForecastAggregationResponse
{
    [JsonProperty("forecasts")]
    public List<Dictionary<string, object>> Forecasts { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
