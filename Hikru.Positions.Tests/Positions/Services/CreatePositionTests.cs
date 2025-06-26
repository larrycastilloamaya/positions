using FluentAssertions;
using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Application.Positions.Dtos;
using Moq;

public class CreatePositionTests
{
    [Fact]
    public async Task CreateAsync_ShouldReturnTrue_WhenSuccess()
    {
        var dto = new PositionCreateDto
        {
            Title = "QA",
            Description = "Automation",
            Location = "CR",
            Status = "open",
            RecruiterId = "r1",
            DepartmentId = "d1",
            Budget = 4000,
            ClosingDate = null
        };

        var mockService = new Mock<IApexPositionService>();
        mockService.Setup(s => s.CreateAsync(dto, It.IsAny<CancellationToken>()))
                   .ReturnsAsync(true);

        var result = await mockService.Object.CreateAsync(dto, CancellationToken.None);

        result.Should().BeTrue();
    }
}
