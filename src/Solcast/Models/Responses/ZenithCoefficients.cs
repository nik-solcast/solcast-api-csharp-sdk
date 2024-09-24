using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class ZenithCoefficients
{
    [JsonProperty("day_of_year")]
    public int? DayOfYear { get; set; } 
    [JsonProperty("signed_zenith_coefficients")]
    public IDictionary<string, object> SignedZenithCoefficients { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
