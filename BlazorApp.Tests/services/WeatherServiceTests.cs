using Xunit;
using BlazorApp.Models;
using BlazorApp.Services;

namespace BlazorApp.Tests.Services;

public class WeatherServiceTests
{
    private readonly WeatherService _weatherService;

    public WeatherServiceTests()
    {
        _weatherService = new WeatherService();
    }

    [Fact]
    public async Task GetForecastAsync_ReturnsFiveForecasts()
    {
        // Act
        var result = await _weatherService.GetForecastAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Length);
    }

    [Fact]
    public void TemperatureF_Calculation_IsCorrect()
    {
        // Arrange
        var forecast = new WeatherForecast { TemperatureC = 0 };

        // Act
        var fahrenheit = forecast.TemperatureF;

        // Assert
        Assert.Equal(32, fahrenheit);
    }
}