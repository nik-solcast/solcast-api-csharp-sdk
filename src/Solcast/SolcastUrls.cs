namespace Solcast
{
    public static class SolcastUrls
    {
        public static readonly string BaseUrl = "https://api.solcast.com.au";
        
        // Live data endpoints
        public static readonly string LiveRadiationAndWeather = "data/live/radiation_and_weather";
        public static readonly string LiveRooftopPvPower = "data/live/rooftop_pv_power";
        public static readonly string LiveAdvancedPvPower = "data/live/advanced_pv_power";
        public static readonly string LiveGridAggregations = "data/live/aggregations";

        // Historic data endpoints
        public static readonly string HistoricRadiationAndWeather = "data/historic/radiation_and_weather";
        public static readonly string HistoricRooftopPvPower = "data/historic/rooftop_pv_power";
        public static readonly string HistoricAdvancedPvPower = "data/historic/advanced_pv_power";

        // Forecast data endpoints
        public static readonly string ForecastRadiationAndWeather = "data/forecast/radiation_and_weather";
        public static readonly string ForecastRooftopPvPower = "data/forecast/rooftop_pv_power";
        public static readonly string ForecastAdvancedPvPower = "data/forecast/advanced_pv_power";
        public static readonly string ForecastGridAggregations = "data/forecast/aggregations";

        // TMY data endpoints
        public static readonly string TmyRadiationAndWeather = "data/tmy/radiation_and_weather";
        public static readonly string TmyRooftopPvPower = "data/tmy/rooftop_pv_power";

        // PV Power Site endpoints
        public static readonly string PvPowerSite = "resources/pv_power_site";
        public static readonly string PvPowerSites = "resources/pv_power_sites";
    }
}
