using Newtonsoft.Json;
using System.Collections.Generic;

public class ListPvPowerResources
{

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
