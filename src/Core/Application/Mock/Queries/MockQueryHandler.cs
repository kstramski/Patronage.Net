using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;

namespace Application.Mock.Queries
{
    public class MockQueryHandler : IRequestHandler<MockQuery, string>
    {
        private readonly IMockIOService _mockIOService;

        public MockQueryHandler(IMockIOService mockIoService)
        {
            _mockIOService = mockIoService;
        }

        public async Task<string> Handle(MockQuery request, CancellationToken cancellationToken)
        {
            return await _mockIOService.MockContent();
        }
    }
}
