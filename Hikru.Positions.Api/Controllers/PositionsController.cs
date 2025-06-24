using Hikru.Positions.Application.Positions.Commands;
using Hikru.Positions.Application.Positions.Queries.GetAllFromApex;
using Hikru.Positions.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hikru.Positions.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PositionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Próximamente implementaremos la query CQRS
            return Ok(new { Id = id, Message = "GET /positions/{id} en construcción" });
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllFromApexQuery());
            return Ok(result);
        }
    }
}
