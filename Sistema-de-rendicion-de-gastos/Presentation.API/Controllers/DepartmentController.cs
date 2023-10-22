using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Presentation.API.Handlers;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(DepartmentResponse), 200)]
        [ProducesResponseType(typeof(MessageResponse), 404)]
        public async Task<IActionResult> GetCompany(int id)
        {
            var result = await _departmentService.GetDepartment(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAll/")]
        [ProducesResponseType(typeof(List<DepartmentResponse>), 200)]
        public async Task<IActionResult> GetDepartments()
        {
            var result = await _departmentService.GetDepartments();

            return Ok(result);
        }
        
        [HttpPost]
        [Route("Insert/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(MessageResponse), 400)]
        public async Task<IActionResult> CreateDepartment(DepartmentRequest request)
        {
            await _departmentService.CreateDepartment(request);

            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
