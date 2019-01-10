using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMockIOService
    {
        Task<string> MockContent();
    }
}
