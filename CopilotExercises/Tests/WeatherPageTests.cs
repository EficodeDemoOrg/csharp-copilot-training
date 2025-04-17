using Bunit;
using Microsoft.Extensions.DependencyInjection;
using BlazorUI.Components.Pages;
using Backend;
using Moq;
using Moq.Protected;

namespace Tests;

public class WeatherPageTests : TestContext
{
    private Mock<HttpMessageHandler> _mockHttpMessageHandler;
    private HttpClient _mockHttpClient;

    public WeatherPageTests()
    {
        // Set up mock HTTP handler
        _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        _mockHttpClient = new HttpClient(_mockHttpMessageHandler.Object)
        {
            BaseAddress = new Uri("http://localhost")
        };

        // Register the mock HttpClient in the service provider
        Services.AddSingleton(_mockHttpClient);
    }

    [Fact]
    public void WeatherPage_ShouldRenderLoading_WhenForecastsAreNull()
    {
        // Create a TaskCompletionSource to control when the HTTP request completes
        var tcs = new TaskCompletionSource<HttpResponseMessage>();
        
        // Set up the HTTP handler to return a task that won't complete until we want it to
        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns(tcs.Task); // This task won't complete during the test
        
        // Act - Render the component 
        var component = RenderComponent<Weather>();
        
        // Assert - The component should show the loading message since the HTTP request hasn't completed
        var paragraphs = component.FindAll("p");
        var loadingParagraph = paragraphs.FirstOrDefault(p => p.InnerHtml.Contains("Loading"));
        
        Assert.NotNull(loadingParagraph);
        Assert.Contains("Loading...", loadingParagraph.InnerHtml);
    }

    [Fact]
    public void WeatherPage_ShouldRenderTable_WhenForecastsAreLoaded()
    {
        // Arrange - Set up the HTTP response with test data
        var forecasts = new[]
        {
            new WeatherForecast { Date = new DateOnly(2025, 4, 11), TemperatureC = 20, Summary = "Sunny" },
            new WeatherForecast { Date = new DateOnly(2025, 4, 12), TemperatureC = 15, Summary = "Cloudy" }
        };

        // Act - Render the component with test forecasts directly
        var component = RenderComponent<Weather>(parameters => parameters
            .Add(p => p.ForecastsForTest, forecasts));

        // Assert - Should show table with two rows
        var tableRows = component.FindAll("tbody tr");
        Assert.Equal(2, tableRows.Count);
    }
}