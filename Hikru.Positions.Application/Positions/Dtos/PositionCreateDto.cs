namespace Hikru.Positions.Application.Positions.Dtos;

public class PositionCreateDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Status { get; set; } = "open";
    public string RecruiterId { get; set; } = null!;
    public string DepartmentId { get; set; } = null!;
    public decimal Budget { get; set; }
    public DateTime? ClosingDate { get; set; }
}
