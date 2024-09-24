using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class ResponseError
{
    [JsonProperty("error_code")]
    public string ErrorCode { get; set; } 
    [JsonProperty("field_name")]
    public string FieldName { get; set; } 
    [JsonProperty("message")]
    public string Message { get; set; } 
    [JsonProperty("meta")]
    public IDictionary<string, object> Meta { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
