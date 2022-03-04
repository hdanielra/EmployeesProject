using Employees.Contracts;
using System.Net.Http;

namespace Employees.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private IEmployeeRepository _employee;

        // --------------------------------------------------------
        private readonly IExternalService _externalService;
        public RepositoryManager(IExternalService externalService)
        {
            _externalService = externalService;
        }
        // --------------------------------------------------------



        // --------------------------------------------------------
        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                    _employee = new EmployeeRepository(_externalService);

                return _employee;
            }
        }
        // --------------------------------------------------------



    }
}