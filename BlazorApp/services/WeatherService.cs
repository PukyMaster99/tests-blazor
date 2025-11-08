using BlazorApp.Models;  // ✅ Agregar este using

namespace BlazorApp.Services;

public class WeatherService : IWeatherService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<WeatherForecast[]> GetForecastAsync()  // ✅ Agregar async
    {
        // Simular una operación asíncrona
        await Task.Delay(100);
        
        var forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();

        return forecast;
    }

    public async Task<WeatherForecast[]> GetForecastByTemperatureAsync(int minTemperature)  // ✅ Agregar async
    {
        // Simular una operación asíncrona
        await Task.Delay(100);
        
        var forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(minTemperature, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();

        return forecast;
    }
}