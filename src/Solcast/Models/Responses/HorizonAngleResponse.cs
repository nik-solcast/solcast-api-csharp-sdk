using Newtonsoft.Json;
using System.Collections.Generic;

public class HorizonAngleResponse
{
    [JsonProperty("horizon_angles")]
    public List<HorizonAngle> HorizonAngles { get; set; } 
    [JsonProperty("response_status")]
    public string ResponseStatus { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
