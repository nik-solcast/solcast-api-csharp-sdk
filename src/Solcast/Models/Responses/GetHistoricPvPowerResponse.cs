using Newtonsoft.Json;
using System.Collections.Generic;

public class GetHistoricPvPowerResponse
{
    [JsonProperty("estimated_actuals")]
    public List<Dictionary_String_Object_> EstimatedActuals { get; set; } 
    [JsonProperty("header_metadata")]
    public IResponseMetadata HeaderMetadata { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
