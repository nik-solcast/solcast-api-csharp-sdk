using Newtonsoft.Json;
using System.Collections.Generic;

public class GetPvPowerResource
{
    [JsonProperty("resource_id")]
    public string ResourceId { get; set; } // Required

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
