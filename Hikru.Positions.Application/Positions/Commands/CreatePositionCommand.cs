using MediatR;

namespace Hikru.Positions.Application.Positions.Commands
{
    public class CreatePositionCommand : IRequest<int>
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Status { get; set; } = "draft";
        public int RecruiterId { get; set; }
        public int DepartmentId { get; set; }
        public decimal Budget { get; set; }
        public DateTime? ClosingDate { get; set; }
    }
}