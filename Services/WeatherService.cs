using System.Runtime.CompilerServices;
using Weather.Api.Dtos;
using Weather.Api.Models;

namespace Weather.Api.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpRequestService _httpRequestService;
        public WeatherService(IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
        }

        public async Task<ForecastResponse> GetForecastAsync(ForecastRequest forecastRequest, CancellationToken cancellationToken)
        {
            ForecastResponse forecastResponse = new ForecastResponse();
            var data = await _httpRequestService.GetAsync<ForecastMetaData>("ApiWebService", $"/points/{forecastRequest.Latitude},{forecastRequest.Longitude}", cancellationToken);

            if (!string.IsNullOrWhiteSpace(data.Properties.Forecast))
            {

                string GetTemperatureDescription(int temperature)
                {
                    if (temperature <= 50)
                    {
                        return "Cold";
                    }
                    if (temperature <= 75)
                    {
                        return "Mild";
                    }

                    return "Hot";
                }

                try
                {

                    var forecast = await _httpRequestService.GetAsync<Forecast>("ApiWebService", data.Properties.Forecast, cancellationToken);

                    forecast.Properties.Periods.ToList().ForEach(p => p.TemperatureDescription = GetTemperatureDescription(p.Temperature));

                    forecastResponse.Success = true;
                    forecastResponse.TimePeriods = forecast.Properties.Periods.Take(5);
                }
                catch (Exception ex)
                {
                    forecastResponse.ErrorMessage = ex.Message;
                }
            }

            return forecastResponse;
        }
    }
}
