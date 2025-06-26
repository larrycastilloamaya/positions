using FluentAssertions;
using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Application.Positions.Dtos;
using Moq;

public class UpdatePositionTests
{
    [Fact]
    public async Task UpdateAsync_ShouldReturnTrue_WhenSuccess()
    {
        // Arrange
        var dto = new UpdatePositionDto
        {
            Id = "abc123",
            Title = "Updated Title",
            Description = "Updated description",
            Location = "Remote",
            Status = "open",
            RecruiterId = "rec1",
            DepartmentId = "dep1",
            Budget = 7000,
            ClosingDate = null
        };

        var mockService = new Mock<IApexPositionService>();
        mockService.Setup(s => s.UpdateAsync(dto, It.IsAny<CancellationToken>()))
                   .ReturnsAsync(true);

        // Act
        var result = await mockService.Object.UpdateAsync(dto, CancellationToken.None);

        // Assert
        result.Should().BeTrue();
    }
}
