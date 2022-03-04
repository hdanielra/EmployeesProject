using Employees.Contracts;
using Employees.Entities.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Employees.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {

        private readonly IRepositoryManager _repositoryManager;
        public EmployeesController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
         
        }



        // -------------------------------------------------------------------------------------------------
        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<DataResponse>> Get()
        {
            DataResponse dataResponse = await _repositoryManager.Employee.FindAll();

            // serialize, convert to json
            return Ok(JsonConvert.SerializeObject(dataResponse));
        }
        // -------------------------------------------------------------------------------------------------





        // -------------------------------------------------------------------------------------------------
        // GET: api/employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int Id)
        {

            DataResponse dataResponse = await _repositoryManager.Employee.FindById(Id);

            // serialize, convert to json
            return Ok(JsonConvert.SerializeObject(dataResponse));
        }
        // -------------------------------------------------------------------------------------------------


    }
}
