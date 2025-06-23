using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Domain.Entities;
using MediatR;

namespace Hikru.Positions.Application.Positions.Commands
{
    public class CreatePositionHandler : IRequestHandler<CreatePositionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePositionHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = new Position
            {
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                Status = request.Status,
                RecruiterId = request.RecruiterId,
                DepartmentId = request.DepartmentId,
                Budget = request.Budget,
                ClosingDate = request.ClosingDate
            };

            _context.Positions.Add(position);
            await _context.SaveChangesAsync(cancellationToken);
            return position.Id;
        }
    }
}
