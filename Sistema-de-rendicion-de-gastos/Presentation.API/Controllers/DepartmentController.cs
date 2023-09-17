﻿using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
