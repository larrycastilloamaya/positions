using Hikru.Positions.Application.Interfaces;
using MediatR;

namespace Hikru.Positions.Application.Positions.Commands.Create;

public class CreatePositionHandler : IRequestHandler<CreatePositionCommand, bool>
{
    private readonly IApexPositionService _service;

    public CreatePositionHandler(IApexPositionService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
    {
        return await _service.CreateAsync(request.Dto, cancellationToken);
    }
}
