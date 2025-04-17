using System.Net.Http.Json;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using System.Net;
using System.Text.Json;

namespace Tests;

/// <summary>
/// Integration tests for validating the application in a Docker environment.
/// Uses Testcontainers to programmatically create, configure, and test Docker containers.
/// </summary>
[Trait("Category", "Docker")]
public class DockerIntegrationTests : IAsyncLifetime
{
    private readonly IContainer _backendContainer;
    private HttpClient _httpClient; // Made non-readonly to set BaseAddress later

    public DockerIntegrationTests()
    {
        // Configure the backend container with proper settings for a Docker environment
        var randomSuffix = Guid.NewGuid().ToString("N").Substring(0, 8); // Generate a random 8-character suffix
        _backendContainer = new ContainerBuilder()
            .WithImage("mcr.microsoft.com/dotnet/aspnet:8.0")
            .WithName($"backend-test-container-{randomSuffix}") // Add randomness to the container name
            .WithPortBinding(80, true) // Bind container port 80 to a random host port
            .WithBindMount(
            Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "Backend", "bin", "Debug", "net8.0")), // Corrected relative path
            "/app", AccessMode.ReadWrite)
            .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development")
            .WithEnvironment("ASPNETCORE_URLS", "http://+:80") // Ensure Kestrel listens on port 80
            .WithEnvironment("DOTNET_RUNNING_IN_CONTAINER", "true") // Signal to app it's running in Docker
            .WithWorkingDirectory("/app")
            .WithCommand("dotnet", "Backend.dll")
            // Refined wait strategy: Wait for HTTP success on Swagger UI path
            .WithWaitStrategy(Wait.ForUnixContainer()
            .UntilHttpRequestIsSucceeded(request => request.ForPort(80).ForPath("/swagger")))
            .Build();

        // Create HttpClient - BaseAddress will be set in InitializeAsync
        _httpClient = new HttpClient();
    }

    public async Task InitializeAsync()
    {
        // Start the container before tests run
        await _backendContainer.StartAsync();

        // Get the dynamically assigned host port and set BaseAddress
        var mappedPort = _backendContainer.GetMappedPublicPort(80);
        _httpClient.BaseAddress = new Uri($"http://{_backendContainer.Hostname}:{mappedPort}");
    }

    public async Task DisposeAsync()
    {
        // Clean up resources after tests complete
        _httpClient?.Dispose(); // Dispose HttpClient
        await _backendContainer.StopAsync();
    }

    [Fact]
    public async Task WeatherForecastEndpoint_ShouldReturnSuccessAndData_InDockerEnvironment()
    {
        // Act - Call the API endpoint
        var response = await _httpClient.GetAsync("/api/weatherforecast");

        // Assert - Verify proper response from container
        response.EnsureSuccessStatusCode(); // Use EnsureSuccessStatusCode for clearer failure
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // Verify we get JSON data back without needing the WeatherForecast type
        var jsonContent = await response.Content.ReadAsStringAsync();
        using var forecasts = JsonDocument.Parse(jsonContent); // Use using for JsonDocument

        Assert.Equal(JsonValueKind.Array, forecasts.RootElement.ValueKind); // Check RootElement
        Assert.True(forecasts.RootElement.GetArrayLength() > 0, "Response should contain weather forecast items");

        // Verify the first forecast item has the expected properties
        var firstForecast = forecasts.RootElement[0];
        Assert.True(firstForecast.TryGetProperty("date", out _), "Forecast should have a date property");
        Assert.True(firstForecast.TryGetProperty("temperatureC", out _), "Forecast should have a temperatureC property");
        Assert.True(firstForecast.TryGetProperty("temperatureF", out _), "Forecast should have a temperatureF property");
        Assert.True(firstForecast.TryGetProperty("summary", out _), "Forecast should have a summary property");
    }

    [Fact]
    public async Task CounterEndpoint_ShouldIncrementCounter_InDockerEnvironment()
    {
        // Act - Increment the counter
        var incrementResponse = await _httpClient.PostAsync("/api/counter/increment", null);
        incrementResponse.EnsureSuccessStatusCode();

        // Get the counter value
        var getResponse = await _httpClient.GetAsync("/api/counter");
        getResponse.EnsureSuccessStatusCode();

        // Assert - Verify counter was incremented in the Docker container
        var counterValue = await getResponse.Content.ReadFromJsonAsync<int>();
        Assert.True(counterValue > 0, "Counter should be incremented in Docker environment");
    }

    [Fact]
    public async Task DockerContainer_ShouldBeHealthy()
    {
        // Verify the container is properly responding to a known endpoint
        var healthResponse = await _httpClient.GetAsync("/api/weatherforecast"); // Use the same endpoint as wait strategy
        Assert.True(healthResponse.IsSuccessStatusCode, "Container should respond successfully to /api/weatherforecast");
    }
}