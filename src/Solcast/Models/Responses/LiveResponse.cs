using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class LiveResponse
{
    [JsonProperty("estimated_actuals")]
    public List<Dictionary<string, object>> EstimatedActuals { get; set; } 
    [JsonProperty("response_status")]
    public string ResponseStatus { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
