using FluentAssertions;
using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Application.Positions.Commands.Delete;
using Moq;

namespace Hikru.Positions.Tests.Positions.Commands.DeletePosition
{
    public class DeletePositionHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnTrue_WhenDeleted()
        {
            var mockService = new Mock<IApexPositionService>();

            mockService.Setup(s => s.DeleteAsync("123", It.IsAny<CancellationToken>()))
                       .ReturnsAsync(true);

            var handler = new DeletePositionHandler(mockService.Object);
            var command = new DeletePositionCommand("123");

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().BeTrue();
        }
    }
}
