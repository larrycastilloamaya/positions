using Hikru.Positions.Application.Departments.Dtos;
using MediatR;

namespace Hikru.Positions.Application.Departments.Queries.GetAllFromApex
{
    public class GetAllDepartmentsQuery : IRequest<List<DepartmentDto>> { }
}
