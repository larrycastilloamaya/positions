using Hikru.Positions.Application.Positions.Dtos;
using MediatR;

namespace Hikru.Positions.Application.Positions.Queries.GetByIdFromApex;

public class GetByIdFromApexQuery : IRequest<PositionDto?>
{
    public string Id { get; }

    public GetByIdFromApexQuery(string id)
    {
        Id = id;
    }
}
