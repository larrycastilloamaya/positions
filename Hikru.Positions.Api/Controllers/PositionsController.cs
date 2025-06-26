using Hikru.Positions.Application.Positions.Commands.Create;
using Hikru.Positions.Application.Positions.Commands.Delete;
using Hikru.Positions.Application.Positions.Commands.Update;
using Hikru.Positions.Application.Positions.Dtos;
using Hikru.Positions.Application.Positions.Queries.GetAllFromApex;
using Hikru.Positions.Application.Positions.Queries.GetByIdFromApex;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create([FromBody] PositionCreateDto dto)
        {
            var success = await _mediator.Send(new CreatePositionCommand(dto));
            return success ? Ok("Posición creada correctamente.") : BadRequest("No se pudo crear la posición.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdatePositionDto dto)
        {
            dto.Id = id; // aseguramos que el id del path se use
            var result = await _mediator.Send(new UpdatePositionCommand(dto));
            return result ? Ok("Posición actualizada.") : BadRequest("Error al actualizar.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var success = await _mediator.Send(new DeletePositionCommand(id));
            return success ? Ok("Posición eliminada correctamente.") : NotFound("No se pudo eliminar la posición.");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var position = await _mediator.Send(new GetByIdFromApexQuery(id));
            return position is not null ? Ok(position) : NotFound("Posición no encontrada.");
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllFromApexQuery());
            return Ok(result);
        }

    }
}
