using Hikru.Positions.Application.Positions.Dtos;

namespace Hikru.Positions.Application.Interfaces;

public interface IApexPositionService
{
    Task<List<PositionDto>> GetAllAsync();
}
