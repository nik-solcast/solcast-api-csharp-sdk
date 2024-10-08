using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class GetTmyAdvancedPvPower
{
    [JsonProperty("time_zone")]
    public string TimeZone { get; set; } 
    [JsonProperty("period")]
    public string Period { get; set; } 
    [JsonProperty("ghi_weight")]
    public double? GhiWeight { get; set; } 
    [JsonProperty("dni_weight")]
    public double? DniWeight { get; set; } 
    [JsonProperty("probability")]
    public string Probability { get; set; } 
    [JsonProperty("output_parameters")]
    public List<string> OutputParameters { get; set; } 
    [JsonProperty("resource_id")]
    public string ResourceId { get; set; } // Required
    [JsonProperty("hours")]
    public int? Hours { get; set; } 
    [JsonProperty("apply_availability")]
    public double? ApplyAvailability { get; set; } 
    [JsonProperty("apply_constraint")]
    public double? ApplyConstraint { get; set; } 
    [JsonProperty("apply_dust_soiling")]
    public double? ApplyDustSoiling { get; set; } 
    [JsonProperty("apply_snow_soiling")]
    public double? ApplySnowSoiling { get; set; } 
    [JsonProperty("apply_tracker_inactive")]
    public bool? ApplyTrackerInactive { get; set; } 
    [JsonProperty("terrain_shading")]
    public bool? TerrainShading { get; set; } 
    [JsonProperty("format")]
    public string Format { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
