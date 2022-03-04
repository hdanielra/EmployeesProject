using Employees.Contracts;
using Employees.Repository.Utils;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Employees.Entities.ViewModels;
using System.Net.Http;
using Newtonsoft.Json;
using Employees.Entities.Responses;

namespace Employees.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        // ------------------------------------------------------------------------------
        private readonly IExternalService _externalService;

        public EmployeeRepository(IExternalService externalService)
        {
            _externalService = externalService;
        }
        // ------------------------------------------------------------------------------




        // ------------------------------------------------------------------------------
        public async Task<DataResponse> FindAll()
        {
            return await _externalService.FindAll();
        }
        // ------------------------------------------------------------------------------




        // ------------------------------------------------------------------------------
        public async Task<DataResponse> FindById(int Id)
        {
            return await _externalService.FindById(Id);
        }
        // ------------------------------------------------------------------------------

    }
}