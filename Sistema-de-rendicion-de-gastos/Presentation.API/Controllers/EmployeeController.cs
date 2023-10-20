using Application.DTO.Request;
using Application.Interfaces.IServices;
using Application.UseCases;
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

        [HttpGet]
        [Route("GetIdEmployee/")]
        public IActionResult GetCompany(int id)
        {
            var traking = _employeeService.GetEmployee(id);
            return Ok(traking);
        }

        [HttpGet]
        [Route("GetAllEmployee/")]
        public IActionResult GetEmployee()
        {
            var traking = _employeeService.GetEmployees();
            return Ok(traking);
        }
        [HttpPost]
        [Route("PostEmployee/")]
        public async Task<IActionResult> CreateEmployee(EmployeeRequest request)
        {
            var traking = await _employeeService.CreateEmployee(request);
            return Ok(traking);
        }

    }
}


