
namespace Weather.Api.Models
{
    public class Forecast
    {
        public ForecastProperties Properties { get; set; }
        public IEnumerable<ForecastPeriod> TimePeriods { get; set; }
    }
}
