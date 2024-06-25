using Weather.Api.Dtos;

namespace Weather.Api.Services
{
    public interface IWeatherService
    {
        Task<ForecastResponse> GetForecastAsync(ForecastRequest forecastRequest, CancellationToken cancellationToken);

    }
}
