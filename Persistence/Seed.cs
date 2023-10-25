using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            var weatherForecasts = new List<WeatherForecast>
            {
                new WeatherForecast
                {
                    Id = Guid.NewGuid(),
                    Date = new DateOnly(2023, 10, 25),
                    TemperatureC = 20,
                    Summary = "Partly Cloudy"
                },
                new WeatherForecast
                {
                    Id = Guid.NewGuid(),
                    Date = new DateOnly(2023, 10, 26),
                    TemperatureC = 15,
                    Summary = "Showers"
                },
                new WeatherForecast
                {
                    Id = Guid.NewGuid(),
                    Date = new DateOnly(2023, 10, 27),
                    TemperatureC = 25,
                    Summary = "Sunny"
                },
            };
            await context.WeatherForecasts.AddRangeAsync(weatherForecasts);
            await context.SaveChangesAsync();
        }
    }
}
