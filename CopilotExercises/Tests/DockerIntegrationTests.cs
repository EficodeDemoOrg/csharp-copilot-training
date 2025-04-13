using System.Net.Http.Json;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using System.Net;
using System.Text.Json;
using Xunit;

namespace Tests;

/// <summary>
/// Integration tests for validating the application in a Docker environment.
/// Uses Testcontainers to programmatically create, configure, and test Docker containers.
/// </summary>
[Trait("Category", "Docker")]
public class DockerIntegrationTests : IAsyncLifetime
{
    private readonly IContainer _backendContainer;
    private readonly HttpClient _httpClient;

    public DockerIntegrationTests()
    {
        // Configure the backend container with proper settings for a Docker environment
        _backendContainer = new ContainerBuilder()
            .WithImage("mcr.microsoft.com/dotnet/aspnet:8.0")
            .WithName("backend-test-container")
            .WithPortBinding(8080, 80) // Map container port 80 to host port 8080
            .WithBindMount(
                Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Backend", "bin", "Debug", "net8.0")),
                "/app", AccessMode.ReadWrite)
            .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development")
            .WithEnvironment("DOTNET_RUNNING_IN_CONTAINER", "true") // Signal to app it's running in Docker
            .WithWorkingDirectory("/app")
            .WithCommand("dotnet", "Backend.dll")
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(80))
            .Build();

        // Create HttpClient for making requests to the backend
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:8080")
        };
    }

    public async Task InitializeAsync()
    {
        // Start the container before tests run
        await _backendContainer.StartAsync();
        
        // Add a small delay to ensure the service is fully initialized
        await Task.Delay(TimeSpan.FromSeconds(3));
    }

    public async Task DisposeAsync()
    {
        // Clean up resources after tests complete
        await _backendContainer.StopAsync();
        await _backendContainer.DisposeAsync();
    }

    [Fact(Skip = "Docker tests disabled")]
    public async Task WeatherForecastEndpoint_ShouldReturnSuccessAndData_InDockerEnvironment()
    {
        // Act - Call the API endpoint
        var response = await _httpClient.GetAsync("/weatherforecast");
        
        // Assert - Verify proper response from container
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        // Verify we get JSON data back without needing the WeatherForecast type
        var jsonContent = await response.Content.ReadAsStringAsync();
        var forecasts = JsonSerializer.Deserialize<JsonElement>(jsonContent);
        
        Assert.True(forecasts.ValueKind == JsonValueKind.Array, "Response should be a JSON array");
        Assert.True(forecasts.GetArrayLength() > 0, "Response should contain weather forecast items");
        
        // Verify the first forecast item has the expected properties
        var firstForecast = forecasts[0];
        Assert.True(firstForecast.TryGetProperty("date", out _), "Forecast should have a date property");
        Assert.True(firstForecast.TryGetProperty("temperatureC", out _), "Forecast should have a temperatureC property");
        Assert.True(firstForecast.TryGetProperty("temperatureF", out _), "Forecast should have a temperatureF property");
        Assert.True(firstForecast.TryGetProperty("summary", out _), "Forecast should have a summary property");
    }

    [Fact(Skip = "Docker tests disabled")]
    public async Task CounterEndpoint_ShouldIncrementCounter_InDockerEnvironment()
    {
        // Act - Increment the counter
        var incrementResponse = await _httpClient.PostAsync("/counter/increment", null);
        incrementResponse.EnsureSuccessStatusCode();
        
        // Get the counter value
        var getResponse = await _httpClient.GetAsync("/counter");
        getResponse.EnsureSuccessStatusCode();
        
        // Assert - Verify counter was incremented in the Docker container
        var counterValue = await getResponse.Content.ReadFromJsonAsync<int>();
        Assert.True(counterValue > 0, "Counter should be incremented in Docker environment");
    }

    [Fact(Skip = "Docker tests disabled")]
    public async Task DockerContainer_ShouldBeHealthy()
    {
        // This test specifically validates the Docker container is healthy
        
        // Get container logs to verify it started properly
        var (stdout, stderr) = await _backendContainer.GetLogsAsync();
        
        // Perform simple validation on logs
        Assert.DoesNotContain("Error", stdout);
        Assert.DoesNotContain("Exception", stdout);
        
        // Verify the container is properly responding to health check
        var healthResponse = await _httpClient.GetAsync("/weatherforecast");
        Assert.True(healthResponse.IsSuccessStatusCode, "Container should respond to health check");
    }
}