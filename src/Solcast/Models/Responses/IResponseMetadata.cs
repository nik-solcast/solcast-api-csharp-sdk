using Newtonsoft.Json;
using System.Collections.Generic;

public class IResponseMetadata
{

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
