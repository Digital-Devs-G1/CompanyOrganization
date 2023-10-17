using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }


        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> CreateEmployee()
        {
            return Ok();
        }
    }
}
