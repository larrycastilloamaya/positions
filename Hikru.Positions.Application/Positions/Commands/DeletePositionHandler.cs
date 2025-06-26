using Hikru.Positions.Application.Interfaces;
using MediatR;

namespace Hikru.Positions.Application.Positions.Commands.Delete;

public class DeletePositionHandler : IRequestHandler<DeletePositionCommand, bool>
{
    private readonly IApexPositionService _apex;

    public DeletePositionHandler(IApexPositionService apex)
    {
        _apex = apex;
    }

    public async Task<bool> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
    {
        return await _apex.DeleteAsync(request.Id, cancellationToken);
    }
}
