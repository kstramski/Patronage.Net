using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Patronage.Application.Interfaces
{
    public interface IMockIOService
    {
        Task<string> MockContent();
    }
}
