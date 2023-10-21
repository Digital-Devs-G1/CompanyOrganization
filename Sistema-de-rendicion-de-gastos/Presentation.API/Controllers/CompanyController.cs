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
        //[Authorize]
        public async Task<IActionResult> GetCompany(int id)
        {
            var result = await  _companyService.GetCompany(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetCompanys/")]
        public async Task<IActionResult> GetCompanys()
        {
            var result = await _companyService.GetCompanys();
            return Ok(result);
        }
        
        [HttpPost]
        [Route("PostCompanys/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCompany(CompanyRequest request)
        {
            var result = await _companyService.CreateCompany(request);
            return Ok(result);
        }
    }
}
