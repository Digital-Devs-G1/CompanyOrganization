using Application.DTO.Request;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("GetDepartment/{id}")]
        public async Task<IActionResult> GetDepartment(int id)
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
        [Route("CreateDepartment/")]
        public async Task<IActionResult> CreateDepartment(DepartmentRequest request)
        {
            var traking = await _departmentService.CreateDepartment(request);
            return Ok(traking);
        }
    }
}
