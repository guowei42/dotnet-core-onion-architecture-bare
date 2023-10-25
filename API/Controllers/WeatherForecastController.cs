using Application.WeatherForecasts;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers;

public class WeatherForecastController : BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<List<WeatherForecast>>> GetWeatherForecasts()
    {
        return await Mediator.Send(new List.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WeatherForecast>> GetWeatherForecast(Guid Id)
    {
        return await Mediator.Send(new Details.Query{ Id = Id });
    }

    [HttpPost]
    public async Task<IActionResult> CreateWeatherForecase(WeatherForecast weatherForecast)
    {
        await Mediator.Send(new Create.Command { WeatherForecast = weatherForecast });
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditWeatherForecase(Guid id, WeatherForecast weatherForecast)
    {
        weatherForecast.Id = id;
        await Mediator.Send(new Edit.Command { WeatherForecast = weatherForecast });
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EditWeatherForecase(Guid id)
    {
        await Mediator.Send(new Delete.Command { Id = id });
        return Ok();
    }
}
