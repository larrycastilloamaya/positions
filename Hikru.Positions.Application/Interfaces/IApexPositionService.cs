using Hikru.Positions.Application.Positions.Dtos;

namespace Hikru.Positions.Application.Interfaces;

public interface IApexPositionService
{
    Task<List<PositionDto>> GetAllAsync();
    Task<bool> CreateAsync(PositionCreateDto dto, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(UpdatePositionDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken);
    Task<PositionDto?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
