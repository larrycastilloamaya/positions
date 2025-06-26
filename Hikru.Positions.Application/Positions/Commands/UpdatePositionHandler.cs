using Hikru.Positions.Application.Interfaces;
using MediatR;

namespace Hikru.Positions.Application.Positions.Commands.Update;

public class UpdatePositionHandler : IRequestHandler<UpdatePositionCommand, bool>
{
    private readonly IApexPositionService _apex;

    public UpdatePositionHandler(IApexPositionService apex)
    {
        _apex = apex;
    }

    public async Task<bool> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
    {
        return await _apex.UpdateAsync(request.Dto, cancellationToken);
    }
}
