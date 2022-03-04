using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Employees.Entities.ViewModels;
using System.Collections.Generic;
using Employees.Entities.Responses;

namespace Employees.App.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly HttpClient _httpClient;
        public EmployeesController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ServiceApi");
        }


        // -----------------------------------------------------------------------------------------------
        // GET: EmployeesController
        public async Task<IActionResult> Index()
        {
            List<EmployeeDisplayViewModel> employees = new();

            HttpResponseMessage res = await _httpClient.GetAsync("api/employees");

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                DataResponse dataResponse = JsonConvert.DeserializeObject<DataResponse>(results);
                if (dataResponse.Data != null)
                {
                    employees = JsonConvert
                        .DeserializeObject<List<EmployeeDisplayViewModel>>(dataResponse.Data.ToString());
                }
            }

            return View(employees);
        }
        // -----------------------------------------------------------------------------------------------



        // -----------------------------------------------------------------------------------------------
        // GET: EmployeesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            EmployeeDisplayViewModel employee = new();

            HttpResponseMessage res = await _httpClient.GetAsync($"api/employees/{id}");

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                DataResponse dataResponse = JsonConvert.DeserializeObject<DataResponse>(results);
                if (dataResponse.Data != null)
                {
                    employee = JsonConvert
                        .DeserializeObject<EmployeeDisplayViewModel>(dataResponse.Data.ToString());
                }
            }

            return View(employee);
        }
        // -----------------------------------------------------------------------------------------------


    }
}
