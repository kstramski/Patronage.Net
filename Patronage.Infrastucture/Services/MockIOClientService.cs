using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Patronage.Infrastructure
{
    public class MockIOClientService
    {
        public async Task<string> GetContent(HttpClient client)
        {
            client.BaseAddress = new Uri("http://www.mocky.io");
            var response = await client.GetAsync("/v2/5c127054330000e133998f85");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
