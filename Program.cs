using Weather.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var apiWebServiceUrl = builder.Configuration.GetSection("ApiWebServiceUrl")?.Value;

builder.Services.AddHttpClient("ApiWebService", config =>
{
    config.BaseAddress = new Uri(apiWebServiceUrl ?? "");
});

builder.Services.AddScoped<IHttpRequestService, HttpRequestService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
