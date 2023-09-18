using Application.DTO.Request;
using Application.Interfaces.IServices;
using Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;

        }

        [HttpGet]
        [Route("GetCompany/{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var traking = await _companyService.GetCompany(id);
            return Ok(traking);
        }

        [HttpGet]
        [Route("GetCompanys/")]
        public async Task<IActionResult> GetCompanys()
        {
            var traking = await _companyService.GetCompanys();
            return Ok(traking);
        }

        [HttpPost]
        [Route("PostDepartments/")]
        public async Task<IActionResult> CreateDepartment(CompanyRequest request)
        {
            var traking = await _companyService.CreateCompany(request);
            return Ok(traking);
        }
    }
}
