using Domain;
using FluentValidation;

namespace Application.WeatherForecasts
{
    public class WeatherForecastsValidator : AbstractValidator<WeatherForecast>
    {
        public WeatherForecastsValidator()
        {
            RuleFor(x => x.TemperatureF).NotEmpty();
            RuleFor(x => x.TemperatureC).NotEmpty();
            RuleFor(x => x.Summary).NotEmpty();
        }
    }
}
