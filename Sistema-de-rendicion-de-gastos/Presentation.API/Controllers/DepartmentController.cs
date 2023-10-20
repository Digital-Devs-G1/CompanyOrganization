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
        private IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("GetDepartment/{id}")]
        public IActionResult GetCompany(int id)
        {
            var traking = _departmentService.GetDepartment(id);
            return Ok(traking);
        }

        [HttpGet]
        [Route("GetDepartments/")]
        public IActionResult GetDepartments()
        {
            var traking = _departmentService.GetDepartments();
            return Ok(traking);
        }
        
        [HttpPost]
        [Route("PostDepartments/")]
        public async Task<IActionResult> CreateDepartment(DepartmentRequest request)
        {
            var traking = await _departmentService.CreateDepartment(request);
            return Ok(traking);
        }

    }
}
