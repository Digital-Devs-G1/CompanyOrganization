using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces.IServices;
using Application.UseCases;
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

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(MessageResponse), 400)]
        public async Task<IActionResult> DeletePosition(int id)
        {
            await _employeeService.DeleteEmployee(id);

            return Ok();
        }

        [HttpGet]
        [Route("ObtenerAprobador/{monto}")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> UpdateAprrover(int monto)
        {
            string idUser = JwtHelper.GetClaimValue(Request.Headers["Authorization"], TypeClaims.Id);

            var value = await _employeeService.NextApprover(Convert.ToInt32(idUser),monto);

            return Ok(value);
        }


        [HttpPatch]
        [Route("HistoryFlagON")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AcceptHistoryFlag()
        {
            await _employeeService.AcceptHistoryFlag(2);
            return Ok();
        }

        [HttpPatch]
        [Route("HistoryFlagOFF")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DissmisHistoryFlag()
        {
            await _employeeService.DissmisHistoryFlag(2);
            return Ok();
        }

        [HttpPatch]
        [Route("ApprovalsFlagON")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AcceptApprovalsFlagFlag()
        {
            await _employeeService.AcceptApprovalsFlagFlag(2);
            return Ok();
        }

        [HttpPatch]
        [Route("ApprovalsFlagOFF")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DissmisApprovalsFlag()
        {
            await _employeeService.DissmisApprovalsFlag(2);
            return Ok();
        }
    }
}


