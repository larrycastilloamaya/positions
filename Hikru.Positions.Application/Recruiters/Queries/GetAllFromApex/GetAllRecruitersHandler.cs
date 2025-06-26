using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Application.Recruiters.Dtos;
using MediatR;

namespace Hikru.Positions.Application.Recruiters.Queries.GetAllFromApex;

public class GetAllRecruitersHandler : IRequestHandler<GetAllRecruitersQuery, List<RecruiterDto>>
{
    private readonly IApexRecruiterService _service;

    public GetAllRecruitersHandler(IApexRecruiterService service)
    {
        _service = service;
    }

    public async Task<List<RecruiterDto>> Handle(GetAllRecruitersQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAllAsync();
    }
}
