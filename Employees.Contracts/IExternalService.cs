using Employees.Entities.Responses;
using System.Threading.Tasks;

namespace Employees.Contracts
{
    public interface IExternalService
    {
        Task<DataResponse> FindAll();
        Task<DataResponse> FindById(int Id);
    }
}