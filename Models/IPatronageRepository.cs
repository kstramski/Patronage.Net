using System.Net.Http;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public interface IPatronageRepository
    {
        string FizzBuzz(int number);
        Task<string> GetMockyContent(HttpClient client);
    }
}