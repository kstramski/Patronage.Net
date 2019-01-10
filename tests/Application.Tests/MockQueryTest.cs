using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Mock.Queries;
using Infrastructure.Services;
using Moq;
using Xunit;

namespace Application.Tests
{
    public class MockQueryTest
    {
        private readonly IMockIOService _mockService;
        private readonly MockQueryHandler _handler;

        public MockQueryTest()
        {
            _mockService = new MockIOService();
            _handler = new MockQueryHandler(_mockService);
        }

        [Fact]
        public async Task GetMock()
        {
            var result = await _handler.Handle(new MockQuery(), CancellationToken.None);

            Assert.Equal("Czary mary", result);
        }

        [Fact]
        public void MockTest()
        {
            var mockService = new Mock<IMockIOService>();
            mockService.Setup(m => m.MockContent()).ReturnsAsync("Czary mary");
            Assert.Equal("Czary mary", mockService.Object.MockContent().Result);
        }
    }
}
