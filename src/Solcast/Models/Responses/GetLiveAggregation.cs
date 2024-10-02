using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class GetLiveAggregation
{
    [JsonProperty("zone")]
    public ZoneType Zone { get; set; } 
    [JsonProperty("aggregation_id")]
    public string AggregationId { get; set; } 
    [JsonProperty("collection_id")]
    public string CollectionId { get; set; } 
    [JsonProperty("period")]
    public string Period { get; set; } 
    [JsonProperty("latitude")]
    public double? Latitude { get; set; } // Required
    [JsonProperty("longitude")]
    public double? Longitude { get; set; } // Required
    [JsonProperty("capacity")]
    public float? Capacity { get; set; } // Required
    [JsonProperty("tilt")]
    public float? Tilt { get; set; } 
    [JsonProperty("azimuth")]
    public float? Azimuth { get; set; } 
    [JsonProperty("install_date")]
    public string InstallDate { get; set; } 
    [JsonProperty("loss_factor")]
    public float? LossFactor { get; set; } 
    [JsonProperty("hours")]
    public int? Hours { get; set; } 
    [JsonProperty("output_parameters")]
    public List<string> OutputParameters { get; set; } 
    [JsonProperty("terrain_shading")]
    public bool? TerrainShading { get; set; } 
    [JsonProperty("format")]
    public string Format { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
