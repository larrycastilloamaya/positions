namespace Hikru.Positions.Application.Positions.Dtos;

public class PositionDto
{
    public string Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string Recruiter_Id { get; set; } = default!;
    public string Department_Id { get; set; } = default!;
    public decimal Budget { get; set; }
    public DateTime? Closing_Date { get; set; }
    public DateTime? Created_At { get; set; }
    public DateTime? Updated_At { get; set; }
}
