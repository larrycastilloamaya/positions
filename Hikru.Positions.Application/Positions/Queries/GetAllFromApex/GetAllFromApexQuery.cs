using Hikru.Positions.Application.Positions.Dtos;
using MediatR;

namespace Hikru.Positions.Application.Positions.Queries.GetAllFromApex;

public class GetAllFromApexQuery : IRequest<List<PositionDto>> { }
