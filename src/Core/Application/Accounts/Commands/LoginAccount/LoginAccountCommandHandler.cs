using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Accounts.Commands.CreateAccount;
using Application.Interfaces;
using MediatR;
using Persistence;

namespace Application.Accounts.Commands.LoginAccount
{
    public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, string>
    {
        private readonly IAccountService _accountService;

        public LoginAccountCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<string> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.Login(request.Email, request.Password);
        }
    }
}
