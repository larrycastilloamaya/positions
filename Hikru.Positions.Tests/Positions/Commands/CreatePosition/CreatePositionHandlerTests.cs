using Moq;
using FluentAssertions;
using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Application.Positions.Commands.Create;
using Hikru.Positions.Application.Positions.Dtos;

namespace Hikru.Positions.Tests.Positions.Commands.Create
{
    public class CreatePositionHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnTrue_WhenCreatedSuccessfully()
        {
            // Arrange
            var dto = new PositionCreateDto
            {
                Title = "Tester",
                Description = "QA Automation",
                Location = "Remote",
                Status = "open",
                Budget = 4800,
                RecruiterId = "rec1",
                DepartmentId = "dep1",
                ClosingDate = null
            };

            var mockService = new Mock<IApexPositionService>();
            mockService.Setup(s => s.CreateAsync(dto, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(true);

            var handler = new CreatePositionHandler(mockService.Object);
            var command = new CreatePositionCommand(dto);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeTrue();
        }
    }
}
