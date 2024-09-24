using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class ForecastResponse
{
    [JsonProperty("forecasts")]
    public List<Dictionary<string, object>> Forecasts { get; set; } 
    [JsonProperty("response_status")]
    public string ResponseStatus { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
