using Newtonsoft.Json;
using System.Collections.Generic;

public class ZoneType
{

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
