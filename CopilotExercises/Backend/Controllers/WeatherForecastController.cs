using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
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

    private IEnumerable<WeatherForecast> RetrieveWeatherData(DateOnly startDate, int days)
    {
        // Simulate data retrieval logic (e.g., from a database or external API)
        return Enumerable.Range(1, days).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });
    }
}
