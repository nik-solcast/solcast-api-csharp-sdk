using Newtonsoft.Json;
using System.Collections.Generic;

public class EstimatedActualsResponse
{
    [JsonProperty("estimated_actuals")]
    public List<Dictionary_String_Object_> EstimatedActuals { get; set; } 
    [JsonProperty("response_status")]
    public ResponseStatus ResponseStatus { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
