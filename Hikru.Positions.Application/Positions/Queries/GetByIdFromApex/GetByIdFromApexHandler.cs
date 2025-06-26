using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Application.Positions.Dtos;
using MediatR;

namespace Hikru.Positions.Application.Positions.Queries.GetByIdFromApex;

public class GetByIdFromApexHandler : IRequestHandler<GetByIdFromApexQuery, PositionDto?>
{
    private readonly IApexPositionService _apex;

    public GetByIdFromApexHandler(IApexPositionService apex)
    {
        _apex = apex;
    }

    public async Task<PositionDto?> Handle(GetByIdFromApexQuery request, CancellationToken cancellationToken)
    {
        return await _apex.GetByIdAsync(request.Id, cancellationToken);
    }
}
