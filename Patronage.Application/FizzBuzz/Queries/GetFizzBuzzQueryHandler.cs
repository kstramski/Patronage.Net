﻿using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Patronage.Application.Exceptions;
using Patronage.Application.Interfaces;

namespace Patronage.Application.FizzBuzz.Queries
{
    public class GetFizzBuzzQueryHandler : IRequestHandler<GetFizzBuzzQuery,string>
    {
        private readonly IFizzBuzzService _fizzBuzzService;

        public GetFizzBuzzQueryHandler(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        public async Task<string> Handle(GetFizzBuzzQuery request, CancellationToken cancellationToken)
        {
            var result = await Task.Run(() => _fizzBuzzService.FizzBuzz(request.Value));

            return result;
        }
    }
}
