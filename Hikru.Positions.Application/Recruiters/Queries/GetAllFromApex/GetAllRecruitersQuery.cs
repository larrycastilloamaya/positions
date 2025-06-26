using Hikru.Positions.Application.Recruiters.Dtos;
using MediatR;

namespace Hikru.Positions.Application.Recruiters.Queries.GetAllFromApex
{
    public class GetAllRecruitersQuery : IRequest<List<RecruiterDto>> { }
}
