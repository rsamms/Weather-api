using Weather.Api.Models;

namespace Weather.Api.Dtos
{
    public class ForecastResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<ForecastPeriod> TimePeriods { get; set; }
    }
}
