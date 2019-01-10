using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Interfaces;

namespace Infrastructure.Services
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
