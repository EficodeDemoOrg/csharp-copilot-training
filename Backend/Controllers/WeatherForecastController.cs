using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/weatherforecast")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly WeatherForecastDbContext _dbContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return _dbContext.WeatherForecasts.ToList();
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast forecast)
    {
        _dbContext.WeatherForecasts.Add(forecast);
        _dbContext.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = forecast.Date }, forecast);
    }
}
