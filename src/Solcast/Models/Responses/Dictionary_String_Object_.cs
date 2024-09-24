using Newtonsoft.Json;
using System.Collections.Generic;

public class Dictionary_String_Object_
{

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
