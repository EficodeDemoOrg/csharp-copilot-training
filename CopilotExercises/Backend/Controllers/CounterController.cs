using Microsoft.AspNetCore.Mvc;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("api/counter")]
public class CounterController : ControllerBase
{
    private readonly CounterService _counterService;

    public CounterController(CounterService counterService)
    {
        _counterService = counterService;
    }

    [HttpPost("Increment")]
    public IActionResult Increment()
    {
        var newValue = _counterService.Increment();
        return Ok(newValue); // Return the updated value
    }

    [HttpGet]
    public IActionResult Get()
    {
        var currentValue = _counterService.GetCounter();
        return Ok(currentValue); // Return the current counter value
    }
}
