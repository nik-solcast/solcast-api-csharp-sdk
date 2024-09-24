using Newtonsoft.Json;
using System.Collections.Generic;

public class GetHistoricForecastRadiationAndWeatherResult
{
    [JsonProperty("historic_forecasts")]
    public List<Dictionary_String_Object_> HistoricForecasts { get; set; } 
    [JsonProperty("header_metadata")]
    public IResponseMetadata HeaderMetadata { get; set; } 

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
}
