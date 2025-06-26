using Hikru.Positions.Application.Departments.Dtos;

namespace Hikru.Positions.Application.Interfaces;

public interface IApexDepartmentService
{
    Task<List<DepartmentDto>> GetAllAsync();
}
