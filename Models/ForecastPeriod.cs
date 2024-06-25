namespace Weather.Api.Models
{
    public class ForecastPeriod
    {
        public string Name { get; set; }
        public int Temperature { get; set; }
        public string TemperatureDescription { get; set; }
        public string ShortForecast { get; set; }
        public string DetailedForecast { get; set; }
    }
}
