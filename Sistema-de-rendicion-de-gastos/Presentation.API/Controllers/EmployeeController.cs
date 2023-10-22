using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces.IServices;
using Infrastructure.Authentication;
using Infrastructure.Authentication.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.API.Handlers;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(EmployeeResponse), 200)]
        public async Task<IActionResult> GetCompany(int id)
        {
            var result = await _employeeService.GetEmployee(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAll/")]
        [ProducesResponseType(typeof(List<EmployeeResponse>), 200)]
        public async Task<IActionResult> GetEmployee()
        {
            var result = await _employeeService.GetEmployees();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetDepartmentByEmployee/")]
        [Authorize]
        [ProducesResponseType(typeof(DepartmentResponse), 200)]
        public async Task<IActionResult> GetDepartmentByEmployee()
        {
            // metodo para obtener el id  del token
            string idUser = JwtHelper.GetClaimValue(Request.Headers["Authorization"], TypeClaims.Id);

            DepartmentResponse result = await _employeeService.GetDepartmentByIdUser(Convert.ToInt32(idUser));

            return Ok(result);
        }

        [HttpPost]
        [Route("Insert/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeRequest request)
        {
            await _employeeService.CreateEmployee(request);

            return StatusCode(StatusCodes.Status201Created);
        }

    }
}


