using Backend.Controllers;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Tests;

public class CounterControllerTests
{
    [Fact]
    public void Increment_IncrementsValue()
    {
        // Arrange
        var counterService = new CounterService();
        var controller = new CounterController(counterService);

        // Act
        var result1 = controller.Increment() as OkObjectResult;
        var result2 = controller.Increment() as OkObjectResult;

        // Assert
        Assert.NotNull(result1);
        Assert.NotNull(result2);
        Assert.Equal(1, result1.Value);
        Assert.Equal(2, result2.Value);
    }

    [Fact]
    public void GetCounter_ReturnsCurrentValue()
    {
        // Arrange
        var counterService = new CounterService();
        var controller = new CounterController(counterService);
        controller.Increment();
        controller.Increment();

        // Act
        var result = controller.Get() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Value);
    }
}
