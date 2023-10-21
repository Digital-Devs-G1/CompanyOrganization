using Application.DTO.Request;
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
        [Route("GetDepartment/{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var result = await _departmentService.GetDepartment(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetDepartments/")]
        public async Task<IActionResult> GetDepartments()
        {
            var result = await _departmentService.GetDepartments();
            return Ok(result);
        }
        
        [HttpPost]
        [Route("PostDepartments/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateDepartment(DepartmentRequest request)
        {
            var result = await _departmentService.CreateDepartment(request);
            return Ok(result);
        }

    }
}
