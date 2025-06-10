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
            var controller = new WeatherForecastController();

            // Act
            

            // Assert
            
        }
    }
}