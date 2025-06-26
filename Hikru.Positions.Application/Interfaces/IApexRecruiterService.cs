using Hikru.Positions.Application.Recruiters.Dtos;

namespace Hikru.Positions.Application.Interfaces;

public interface IApexRecruiterService
{
    Task<List<RecruiterDto>> GetAllAsync();
}
