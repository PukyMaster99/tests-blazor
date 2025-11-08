using BlazorApp.Models;  // ✅ Agregar este using

namespace BlazorApp.Services;

public interface IWeatherService
{
    Task<WeatherForecast[]> GetForecastAsync();
    Task<WeatherForecast[]> GetForecastByTemperatureAsync(int minTemperature);
}