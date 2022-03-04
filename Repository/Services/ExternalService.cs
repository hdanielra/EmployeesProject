using AutoMapper;
using Employees.Contracts;
using Employees.Entities.Responses;
using Employees.Entities.ViewModels;
using Employees.Repository.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Employees.Repository.Services
{
    public class ExternalService: IExternalService
    {
        // ------------------------------------------------------------------------------
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public ExternalService(IHttpClientFactory factory, IMapper mapper)
        {
            _httpClient = factory.CreateClient("ServiceApiExt");
            _mapper = mapper;
        }
        // ------------------------------------------------------------------------------




        // ------------------------------------------------------------------------------
        public async Task<DataResponse> FindAll()
        {
            var maxRetryAttempts = 5;
            DataResponse dataResponse = new();
            List<EmployeeResponse> employeesResponse = new List<EmployeeResponse>();
            List<EmployeeDisplayViewModel> employees = new List<EmployeeDisplayViewModel>();

            try
            {
                await RetryUtil.RetryOnExceptionAsync<HttpRequestException>
                    (maxRetryAttempts, async () =>
                    {
                        //HttpClient client = _api.Initial();
                        HttpResponseMessage res = await _httpClient.GetAsync("api/v1/employees");

                        //res.EnsureSuccessStatusCode();

                        if (res.IsSuccessStatusCode)
                        {
                            var results = res.Content.ReadAsStringAsync().Result;
                            dataResponse = JsonConvert.DeserializeObject<DataResponse>(results);

                            // add the Annual Salary field and remove  the em dash _ in aech field
                            dataResponse = ExtendUtil.TransformAllDataResponse(dataResponse, _mapper);
                        }

                    });
            }
            catch (Exception ex)
            {
                dataResponse.Message += "Exception: " + ex.Message;
            }

            return dataResponse;
        }
        // ------------------------------------------------------------------------------




        // ------------------------------------------------------------------------------
        public async Task<DataResponse> FindById(int Id)
        {
            var maxRetryAttempts = 5;

            DataResponse dataResponse = new();
            EmployeeResponse employeeResponse = new EmployeeResponse();
            EmployeeDisplayViewModel employee = new EmployeeDisplayViewModel();

            try
            {
                await RetryUtil.RetryOnExceptionAsync<HttpRequestException>
                    (maxRetryAttempts, async () =>
                    {
                        //HttpClient client = _api.Initial();
                        HttpResponseMessage res = await _httpClient.GetAsync($"api/v1/employee/{Id}");

                        //res.EnsureSuccessStatusCode();

                        if (res.IsSuccessStatusCode)
                        {
                            var results = res.Content.ReadAsStringAsync().Result;
                            dataResponse = JsonConvert.DeserializeObject<DataResponse>(results);

                            // add the Annual Salary field and remove  the em dash _ in aech field
                            dataResponse = ExtendUtil.TransformOneDataResponse(dataResponse, _mapper);
                        }

                    });
            }
            catch (Exception ex)
            {
                dataResponse.Message += "Exception: " + ex.Message;
            }

            return dataResponse;
        }
        // ------------------------------------------------------------------------------



    }
}
