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
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Route("GetCompany/{id}")]
        [Authorize]
        public async Task<IActionResult> GetCompany(int id)
        {
            var traking =  _companyService.GetCompany(id);
            return Ok(traking);
        }

        [HttpGet]
        [Route("GetCompanys/")]
        public IActionResult GetCompanys()
        {
            var traking = _companyService.GetCompanys();
            return Ok(traking);
        }
        
        [HttpPost]
        [Route("PostCompanys/")]
        public async Task<IActionResult> CreateCompany(CompanyRequest request)
        {
            var traking = await _companyService.CreateCompany(request);
            return Ok(traking);
        }
    }
}
