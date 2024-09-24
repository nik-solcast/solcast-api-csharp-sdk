using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class GetLiveAggregation
{
    [JsonProperty("zone")]
    public ZoneType Zone { get; set; } 
    [JsonProperty("output_parameters")]
    public List<string> OutputParameters { get; set; } 
    [JsonProperty("collection_id")]
    public string CollectionId { get; set; } 
    [JsonProperty("aggregation_id")]
    public string AggregationId { get; set; } 
    [JsonProperty("hours")]
    public int? Hours { get; set; } 
    [JsonProperty("period")]
    public string Period { get; set; } 
    [JsonProperty("format")]
    public string Format { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
