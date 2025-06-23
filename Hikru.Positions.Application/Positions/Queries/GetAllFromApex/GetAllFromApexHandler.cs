using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Application.Positions.Dtos;
using MediatR;

namespace Hikru.Positions.Application.Positions.Queries.GetAllFromApex;

public class GetAllFromApexHandler : IRequestHandler<GetAllFromApexQuery, List<PositionDto>>
{
    private readonly IApexPositionService _service;

    public GetAllFromApexHandler(IApexPositionService service)
    {
        _service = service;
    }

    public async Task<List<PositionDto>> Handle(GetAllFromApexQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAllAsync();
    }
}
