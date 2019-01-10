﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MediatR;

namespace Application.Accounts.Commands.LoginAccount
{
    public class LoginAccountCommand : IRequest<string>
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
