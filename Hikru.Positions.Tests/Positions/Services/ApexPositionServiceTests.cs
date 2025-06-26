using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Hikru.Positions.Application.Positions.Dtos;
using Hikru.Positions.Infrastructure.Options;
using Hikru.Positions.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System.Text.Json;

namespace Hikru.Positions.Tests.Infrastructure.Services
{
    public class ApexPositionServiceTests
    {
        private ApexPositionService CreateService(HttpResponseMessage fakeResponse, out Mock<HttpMessageHandler> mockHandler)
        {
            var options = Options.Create(new ApexApiOptions { BaseUrl = "https://fake-api.com" });
            var logger = new Mock<ILogger<ApexPositionService>>();

            mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(fakeResponse);

            var httpClient = new HttpClient(mockHandler.Object);
            return new ApexPositionService(httpClient, logger.Object, options);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnTrue_WhenSuccess()
        {
            var service = CreateService(new HttpResponseMessage(HttpStatusCode.Created), out _);

            var dto = new PositionCreateDto
            {
                Title = "Test",
                Description = "Testing",
                Location = "CR",
                Status = "open",
                RecruiterId = "r1",
                DepartmentId = "d1",
                Budget = 5000
            };

            var result = await service.CreateAsync(dto, CancellationToken.None);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnPositions_WhenSuccess()
        {
            var json = JsonSerializer.Serialize(new
            {
                items = new[]
                {
                    new PositionDto { Id = "1", Title = "Dev", Description = "Code", Location = "SJ", Status = "open", Budget = 6000 }
                }
            });

            var service = CreateService(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json)
            }, out _);

            var result = await service.GetAllAsync();
            result.Should().HaveCount(1);
            result[0].Title.Should().Be("Dev");
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnTrue_WhenSuccess()
        {
            var service = CreateService(new HttpResponseMessage(HttpStatusCode.OK), out _);

            var dto = new UpdatePositionDto
            {
                Id = "abc123",
                Title = "Updated",
                Description = "Updated Desc",
                Location = "CR",
                Status = "open",
                RecruiterId = "r1",
                DepartmentId = "d1",
                Budget = 5500
            };

            var result = await service.UpdateAsync(dto, CancellationToken.None);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenSuccess()
        {
            var service = CreateService(new HttpResponseMessage(HttpStatusCode.OK), out _);
            var result = await service.DeleteAsync("123", CancellationToken.None);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnPosition_WhenSuccess()
        {
            var dto = new PositionDto
            {
                Id = "1",
                Title = "Dev",
                Description = "Code",
                Location = "Remote",
                Status = "open",
                Budget = 6000
            };

            var json = JsonSerializer.Serialize(dto);

            var service = CreateService(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json)
            }, out _);

            var result = await service.GetByIdAsync("1", CancellationToken.None);
            result.Should().NotBeNull();
            result!.Id.Should().Be("1");
            result.Title.Should().Be("Dev");
        }
    }
}
