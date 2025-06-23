namespace Hikru.Positions.Application.Positions.Dtos;

public class PositionDto
{
    public string Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string RecruiterId { get; set; } = default!;
    public string DepartmentId { get; set; } = default!;
    public decimal Budget { get; set; }
    public DateTime? ClosingDate { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
