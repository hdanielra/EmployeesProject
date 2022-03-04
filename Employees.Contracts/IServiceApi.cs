using System.Net.Http;

namespace Employees.Contracts.Services
{
    public interface IServiceApi
    {
        public HttpClient Initial();
    }
}
