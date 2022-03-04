using Employees.Entities.Responses;
using System.Threading.Tasks;

namespace Employees.Contracts
{
    public interface IRepositoryBase
    {
        Task<DataResponse> FindAll();
        Task<DataResponse> FindById(int Id);
    }
}