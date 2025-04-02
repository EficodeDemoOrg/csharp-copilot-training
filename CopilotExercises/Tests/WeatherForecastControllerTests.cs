using Backend;
using Backend.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Tests
{
    public class WeatherForecastControllerTests
    {
        private WeatherForecastController CreateController(out WeatherForecastDbContext dbContext)
        {
            var options = new DbContextOptionsBuilder<WeatherForecastDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            dbContext = new WeatherForecastDbContext(options);
            var logger = new LoggerFactory().CreateLogger<WeatherForecastController>();
            return new WeatherForecastController(logger, dbContext);
        }

        private (WeatherForecastController Controller, WeatherForecastDbContext DbContext) CreateTestSetup()
        {
            var options = new DbContextOptionsBuilder<WeatherForecastDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Use a unique database for each test
                .Options;
            var dbContext = new WeatherForecastDbContext(options);
            var logger = new LoggerFactory().CreateLogger<WeatherForecastController>();
            var controller = new WeatherForecastController(logger, dbContext);
            return (controller, dbContext);
        }

        [Fact]
        public void TestGetWeatherForecast()
        {
            // Arrange
            var (controller, dbContext) = CreateTestSetup();
            var startDate = DateOnly.FromDateTime(DateTime.Now);

            // Populate the database with weather data
            var weatherData = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "Test Summary"
            }).ToList();

            dbContext.WeatherForecasts.AddRange(weatherData);
            dbContext.SaveChanges();

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
            Assert.All(result, forecast =>
            {
                Assert.InRange(forecast.TemperatureC, -20, 55);
                Assert.False(string.IsNullOrEmpty(forecast.Summary));
            });
        }

        [Fact]
        public void Get_ReturnsWeatherForecasts()
        {
            var (controller, dbContext) = CreateTestSetup();
            dbContext.WeatherForecasts.Add(new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 25, Summary = "Warm" });
            dbContext.SaveChanges();

            var result = controller.Get();

            Assert.Single(result);
        }

        [Fact]
        public void Post_AddsWeatherForecast()
        {
            var (controller, dbContext) = CreateTestSetup();
            var forecast = new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 30, Summary = "Hot" };

            controller.Post(forecast);

            Assert.Single(dbContext.WeatherForecasts);
        }
    }
}