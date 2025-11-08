using Xunit;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using BlazorApp.Services;
using BlazorApp.Models;

namespace BlazorApp.Tests.Components;

public class WeatherComponentTests : TestContext
{
    [Fact]
    public void WeatherComponent_RendersCorrectly()
    {
        // Arrange
        var mockService = new Mock<IWeatherService>();
        var testData = new WeatherForecast[] 
        {
            new() { 
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), 
                TemperatureC = 25, 
                Summary = "Warm" 
            }
        };

        mockService.Setup(x => x.GetForecastAsync())
            .ReturnsAsync(testData);

        Services.AddScoped(_ => mockService.Object);

        // Act
        var component = RenderComponent<BlazorApp.Pages.Weather>(); // ✅ Namespace correcto

        // Assert
        Assert.Contains("Weather Forecast", component.Markup);
    }

    [Fact]
    public void WeatherComponent_ShowsLoadingInitially()
    {
        // Arrange
        var mockService = new Mock<IWeatherService>();
        
        // Configurar el mock para que retorne después de un delay
        mockService.Setup(x => x.GetForecastAsync())
            .Returns(async () => 
            {
                await Task.Delay(100);
                return Array.Empty<WeatherForecast>();
            });

        Services.AddScoped(_ => mockService.Object);

        // Act
        var component = RenderComponent<BlazorApp.Pages.Weather>();

        // Assert - Debería mostrar "Loading..." inicialmente
        Assert.Contains("Loading", component.Markup);
    }

    [Fact]
    public void WeatherComponent_DisplaysForecasts_WhenDataIsLoaded()
    {
        // Arrange
        var mockService = new Mock<IWeatherService>();
        var testData = new WeatherForecast[] 
        {
            new() { 
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), 
                TemperatureC = 25, 
                Summary = "Warm" 
            },
            new() { 
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), 
                TemperatureC = 30, 
                Summary = "Hot" 
            }
        };

        mockService.Setup(x => x.GetForecastAsync())
            .ReturnsAsync(testData);

        Services.AddScoped(_ => mockService.Object);

        // Act
        var component = RenderComponent<BlazorApp.Pages.Weather>();

        // Assert
        component.WaitForState(() => !component.Markup.Contains("Loading"));
        
        Assert.Contains("Warm", component.Markup);
        Assert.Contains("Hot", component.Markup);
        Assert.Contains("25", component.Markup);
        Assert.Contains("30", component.Markup);
    }
}