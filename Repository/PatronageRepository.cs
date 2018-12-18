using System;
using System.Net.Http;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class PatronageRepository : IPatronageRepository
    {
        public string FizzBuzz(int number)
        {
            if (NumberMod(number, 2) && NumberMod(number, 3))
                return "FizzBuzz";
            else if (NumberMod(number, 2))
                return "Fizz";
            else if (NumberMod(number, 3))
                return "Buzz";

            return "";
        }

        public async Task<string> GetMockyContent(HttpClient client)
        {
            client.BaseAddress = new Uri("http://www.mocky.io");
            var response = await client.GetAsync("/v2/5c127054330000e133998f85");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        private bool NumberMod(int number, int mod)
        {
            return (number % mod == 0) ? true : false;
        }
    }
}