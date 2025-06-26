using Hikru.Positions.Application.Recruiters.Queries.GetAllFromApex;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RecruitersController : ControllerBase
{
    private readonly IMediator _mediator;

    public RecruitersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRecruiters()
    {
        var result = await _mediator.Send(new GetAllRecruitersQuery());
        return Ok(result);
    }

}
