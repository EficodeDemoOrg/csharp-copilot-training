using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/weatherforecast")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

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

    [HttpGet("stormreports")]
    public IActionResult GetStormReports()
    {
        var stormReports = new[]
        {
            new { Date = DateTime.Now.AddDays(-1), Description = "Severe thunderstorm with hail" },
            new { Date = DateTime.Now.AddDays(-2), Description = "Tornado warning issued" },
            new { Date = DateTime.Now.AddDays(-3), Description = "Heavy rainfall causing localised flooding" }
        };

        return Ok(stormReports);
    }
}
