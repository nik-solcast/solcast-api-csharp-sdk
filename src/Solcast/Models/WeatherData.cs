using System;

namespace Solcast.Models
{
    public class WeatherData
    {
        public DateTime PeriodEnd { get; set; }
        public double Ghi { get; set; }
        public double Dni { get; set; }
        public double AirTemp { get; set; }
    }
}
