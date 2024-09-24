using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class HorizonAngle
{
    [JsonProperty("azimuth")]
    public double? Azimuth { get; set; } 
    [JsonProperty("angle")]
    public double? Angle { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
