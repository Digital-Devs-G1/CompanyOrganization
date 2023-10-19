using Application.DTO.Request;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.API.Handlers;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("GetDepartment/{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var traking = await _departmentService.GetDepartment(id);
            return Ok(traking);
        }

        [HttpGet]
        [Route("GetDepartments/")]
        public async Task<IActionResult> GetDepartments()
        {
            var traking = await _departmentService.GetDepartments();
            return Ok(traking);
        }

        [HttpPost]
        [Route("PostDepartments/")]
        public async Task<IActionResult> CreateDepartment(DepartmentRequest request)
        {
            var traking = await _departmentService.CreateDepartment(request);
            return Ok(traking);
        }


        [HttpGet]
        [Route("GetDepartmentByEmployee/")]
        [Authorize]
        public async Task<IActionResult> GetDepartmentByEmployee()
        {
            //var result = await _departmentService.GetDepartmentByEmployee(id);
            return Ok();
        }
    }
}
