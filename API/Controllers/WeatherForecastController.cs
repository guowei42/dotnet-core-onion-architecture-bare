using Application.WeatherForecasts;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class WeatherForecastController : BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<List<WeatherForecast>>> GetWeatherForecasts()
    {
        return HandleResult(await Mediator.Send(new List.Query()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WeatherForecast>> GetWeatherForecast(Guid Id)
    {
        return HandleResult(await Mediator.Send(new Details.Query{ Id = Id }));
    }

    [HttpPost]
    public async Task<IActionResult> CreateWeatherForecase(WeatherForecast weatherForecast)
    {
        return HandleResult(await Mediator.Send(new Create.Command { WeatherForecast = weatherForecast }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditWeatherForecase(Guid id, WeatherForecast weatherForecast)
    {
        weatherForecast.Id = id;
        return HandleResult(await Mediator.Send(new Edit.Command { WeatherForecast = weatherForecast }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWeatherForecase(Guid id)
    {
        return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
    }
}
