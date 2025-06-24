using Xunit;
using Moq;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hikru.Positions.Application.Interfaces;
using Hikru.Positions.Application.Positions.Dtos;
using Hikru.Positions.Application.Positions.Queries.GetAllFromApex;

namespace Hikru.Positions.Tests.Positions.Queries.GetAllFromApex
{
    public class GetAllFromApexHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnListOfPositions()
        {
         
            var mockService = new Mock<IApexPositionService>();
            var fakeData = new List<PositionDto>
            {
                new PositionDto { Id = "1", Title = "Dev", Description = "Test", Location = "SJ", Status = "open", Budget = 5000 },
                new PositionDto { Id = "2", Title = "QA", Description = "Test", Location = "Liberia", Status = "draft", Budget = 4500 }
            };

            mockService.Setup(s => s.GetAllAsync())
                       .ReturnsAsync(fakeData);

            var handler = new GetAllFromApexHandler(mockService.Object);

    
            var result = await handler.Handle(new GetAllFromApexQuery(), CancellationToken.None);

         
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result[0].Title.Should().Be("Dev");
        }
    }
}
