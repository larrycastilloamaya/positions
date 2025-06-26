using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Application.Departments.Dtos;
using MediatR;

namespace Hikru.Positions.Application.Departments.Queries.GetAllFromApex;

public class GetAllDepartmentsHandler : IRequestHandler<GetAllDepartmentsQuery, List<DepartmentDto>>
{
    private readonly IApexDepartmentService _service;

    public GetAllDepartmentsHandler(IApexDepartmentService service)
    {
        _service = service;
    }

    public async Task<List<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAllAsync();
    }
}
