using FluentAssertions;
using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Application.Positions.Dtos;
using Moq;

public class GetByIdTests
{
    [Fact]
    public async Task GetByIdAsync_ShouldReturnPosition_WhenExists()
    {
        // Arrange
        var id = "123";
        var expected = new PositionDto
        {
            Id = id,
            Title = "Dev",
            Description = "Backend",
            Location = "Remote",
            Status = "open",
            Budget = 6000
        };

        var mockService = new Mock<IApexPositionService>();
        mockService.Setup(s => s.GetByIdAsync(id, It.IsAny<CancellationToken>()))
                   .ReturnsAsync(expected);

        // Act
        var result = await mockService.Object.GetByIdAsync(id, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result!.Title.Should().Be("Dev");
        result.Id.Should().Be(id);
    }
}
