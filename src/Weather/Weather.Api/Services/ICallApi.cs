using System.Threading.Tasks;

namespace Weather.Api.Services
{
    public interface ICallApi
    {
        Task callApi(string location);
    }
}