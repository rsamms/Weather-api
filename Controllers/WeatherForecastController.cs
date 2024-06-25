using Microsoft.AspNetCore.Mvc;
using Weather.Api.Dtos;
using Weather.Api.Services;

namespace Weather.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetForecastAsync([FromQuery]double latitude, [FromQuery]double longitude, CancellationToken cancellationToken)
        {
            if(latitude == 0.0 || longitude == 0.0)
            {
                return NotFound();
            }
            var forecastRequest = new ForecastRequest { Latitude = latitude, Longitude = longitude };
            var response = await _weatherService.GetForecastAsync(forecastRequest, cancellationToken);

            return Ok(response);
        }
    }
}
