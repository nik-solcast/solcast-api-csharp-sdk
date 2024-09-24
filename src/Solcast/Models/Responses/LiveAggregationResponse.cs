using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class LiveAggregationResponse
{
    [JsonProperty("estimated_actuals")]
    public List<Dictionary<string, object>> EstimatedActuals { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
