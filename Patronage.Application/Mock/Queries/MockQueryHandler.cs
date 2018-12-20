using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Patronage.Application.Exceptions;
using Patronage.Application.Interfaces;

namespace Patronage.Application.Mock.Queries
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
