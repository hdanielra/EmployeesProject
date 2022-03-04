using AutoMapper;
using Employees.Entities.Responses;
using Employees.Entities.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Employees.Repository.Utils
{
    public static class ExtendUtil
    {

        public static DataResponse TransformAllDataResponse(DataResponse dataResponse, IMapper mapper)
        {
            if (dataResponse.Data != null)
            {
                // Deserialize the object, convert from json to object type "List<EmployeeResponse>"
                List<EmployeeResponse> employeesResponse
                    = JsonConvert.DeserializeObject<List<EmployeeResponse>>(dataResponse.Data.ToString());

                // map the object to add a new field
                List<EmployeeDisplayViewModel> employees
                    = mapper.Map<List<EmployeeDisplayViewModel>>(employeesResponse);

                // update de data with the new field
                dataResponse.Data = employees;
            }


            return dataResponse;
        }

        public static DataResponse TransformOneDataResponse(DataResponse dataResponse, IMapper mapper)
        {
            if (dataResponse.Data != null)
            {
                // Deserialize the object, convert from json to object type "EmployeeResponse"
                EmployeeResponse employeeResponse
                    = JsonConvert.DeserializeObject<EmployeeResponse>(dataResponse.Data.ToString());

                // map the object to add a new field
                EmployeeDisplayViewModel employee
                    = mapper.Map<EmployeeDisplayViewModel>(employeeResponse);

                // update de data with the new field
                dataResponse.Data = employee;
            }


            return dataResponse;
        }
    }
}
