using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Patronage.Application.FizzBuzz.Queries;
using Patronage.Application.Interfaces;
using Patronage.Infrastucture;
using Xunit;

namespace Patronage.Application.Tests
{
    public class GetFizzBuzzQueryHandlerTest
    {
        private readonly IFizzBuzzService _fizzBuzzService;
        private readonly GetFizzBuzzQueryHandler _queryHandler;

        public GetFizzBuzzQueryHandlerTest()
        {
            _fizzBuzzService = new FizzBuzzService();
            _queryHandler = new GetFizzBuzzQueryHandler(_fizzBuzzService);
        }

        [Fact]
        public async Task GetBuzz()
        {
            var result = await _queryHandler.Handle(new GetFizzBuzzQuery{Value = 15}, CancellationToken.None);

            Assert.Equal("Buzz", result);
        }

        [Fact]
        public async Task GetFizz()
        {
            var result = await _queryHandler.Handle(new GetFizzBuzzQuery { Value = 20 }, CancellationToken.None);

            Assert.Equal("Fizz", result);
        }

        [Fact]
        public async Task GetFizzBuzz()
        {
            var result = await _queryHandler.Handle(new GetFizzBuzzQuery { Value = 6 }, CancellationToken.None);

            Assert.Equal("FizzBuzz", result);
        }

        [Fact]
        public async Task GetNothing()
        {
            var result = await _queryHandler.Handle(new GetFizzBuzzQuery { Value = 5 }, CancellationToken.None);

            Assert.Equal("", result);
        }

        [Fact]
        public async Task ValueMoreThanThousand()
        {
            try
            {
                var result = await _queryHandler.Handle(new GetFizzBuzzQuery { Value = 2000 }, CancellationToken.None);

            }
            catch (Exception e)
            {
                Assert.Equal("Invalid input value. Value should be between 0 and 1000", e.Message);
            }
        }

        [Fact]
        public async Task ValueLessThanZero()
        {
            try
            {
                var result = await _queryHandler.Handle(new GetFizzBuzzQuery { Value = -30 }, CancellationToken.None);

            }
            catch (Exception e)
            {
                Assert.Equal("Invalid input value. Value should be between 0 and 1000", e.Message);
            }
        }
    }
}
