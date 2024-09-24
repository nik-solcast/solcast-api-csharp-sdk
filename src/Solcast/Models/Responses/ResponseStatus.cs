using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class ResponseStatus
{
    [JsonProperty("error_code")]
    public string ErrorCode { get; set; } 
    [JsonProperty("message")]
    public string Message { get; set; } 
    [JsonProperty("stack_trace")]
    public string StackTrace { get; set; } 
    [JsonProperty("errors")]
    public List<ResponseError> Errors { get; set; } 
    [JsonProperty("meta")]
    public IDictionary<string, object> Meta { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
