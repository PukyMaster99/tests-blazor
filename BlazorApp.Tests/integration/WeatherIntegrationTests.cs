using Xunit;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorApp.Services;

namespace BlazorApp.Tests.Integration;

public class WeatherIntegrationTests : TestContext
{
    [Fact]
    public void WeatherComponent_WithRealService_WorksCorrectly()
    {
        // Arrange - Usar el servicio real
        Services.AddScoped<IWeatherService, WeatherService>();

        // Act
        var cut = RenderComponent<BlazorApp.Pages.Weather>(); // ✅ Namespace corregido

        // Assert
        cut.WaitForState(() => !cut.Markup.Contains("Loading"));

        var tableRows = cut.FindAll("tbody tr");
        Assert.Equal(5, tableRows.Count); // El servicio real genera 5 registros
    }
}