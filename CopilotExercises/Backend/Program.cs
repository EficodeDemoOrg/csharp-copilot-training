using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<WeatherForecastDbContext>(options =>
                options.UseInMemoryDatabase("WeatherForecastDb"));

            var app = builder.Build();

            // Seed the database
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<WeatherForecastDbContext>();
                SeedDatabase(dbContext);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        // Method to seed the database
        private static void SeedDatabase(WeatherForecastDbContext dbContext)
        {
            if (!dbContext.WeatherForecasts.Any())
            {
                var random = new Random();
                var summaries = new[] { "Sunny", "Cloudy", "Rainy", "Windy", "Snowy", "Stormy", "Foggy" };

                var forecasts = Enumerable.Range(0, 14).Select(day => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(day)),
                    TemperatureC = random.Next(-10, 35), // Random temperature between -10°C and 35°C
                    Summary = summaries[random.Next(summaries.Length)] // Random summary
                }).ToArray();

                dbContext.WeatherForecasts.AddRange(forecasts);
                dbContext.SaveChanges();
            }
        }
    }
}
