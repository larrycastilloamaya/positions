using Microsoft.AspNetCore.Mvc;
using Hikru.Positions.Application.Positions.Commands;
using Hikru.Positions.Application.Positions.Queries.GetAllFromApex;
using Hikru.Positions.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hikru.Positions.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllFromApexQuery());
            return Ok(result);
        }
    }
}
