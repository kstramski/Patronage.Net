using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<string> Login(string email, string password);
        Task<string> Register(string email, string password);
    }
}
