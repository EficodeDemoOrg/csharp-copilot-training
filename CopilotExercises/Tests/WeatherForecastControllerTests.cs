using Backend.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public void TestGetWeatherForecast()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
        }
    }
}