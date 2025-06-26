using Moq;
using FluentAssertions;
using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Application.Positions.Commands.Update;
using Hikru.Positions.Application.Positions.Dtos;

namespace Hikru.Positions.Tests.Positions.Commands.Update
{
    public class UpdatePositionHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnTrue_WhenUpdateSucceeds()
        {
            // Arrange
            var dto = new UpdatePositionDto
            {
                Id = "001",
                Title = "Senior Dev",
                Description = "Update test",
                Location = "Remote",
                Status = "open",
                RecruiterId = "r1",
                DepartmentId = "d1",
                Budget = 6000,
                ClosingDate = null
            };

            var mockService = new Mock<IApexPositionService>();
            mockService.Setup(s => s.UpdateAsync(dto, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(true);

            var handler = new UpdatePositionHandler(mockService.Object);
            var command = new UpdatePositionCommand(dto);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeTrue();
            mockService.Verify(s => s.UpdateAsync(dto, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
