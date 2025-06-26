using FluentAssertions;
using Hikru.Positions.Application.Interfaces;
using Moq;

public class DeletePositionTests
{
    [Fact]
    public async Task DeleteAsync_ShouldReturnFalse_WhenFails()
    {
        var id = "89654ADEDS";

        var mockService = new Mock<IApexPositionService>();
        mockService.Setup(s => s.DeleteAsync(id, It.IsAny<CancellationToken>()))
                   .ReturnsAsync(false);

        var result = await mockService.Object.DeleteAsync(id, CancellationToken.None);

        result.Should().BeFalse();
    }
}
