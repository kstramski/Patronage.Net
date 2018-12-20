using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Patronage.Application.Exceptions;
using Patronage.Application.Interfaces;

namespace Patronage.Infrastructure
{
    public class MockIOService : IMockIOService
    {
        public async Task<string> MockContent()
        {
            using(var client = new HttpClient())
            {
                try
                {   var clientService = new MockIOClientService();
                    return await clientService.GetContent(client);
                }
                catch (HttpRequestException)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.InternalServerError, "Mocky.io is not responding.");
                }
            }
        }
    }
}
