using Application.DTO.Request;
using Application.Interfaces.IServices;
using Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private IPayrollService _payrollService;

        public PayrollController(IPayrollService payrollService)
        {
            _payrollService = payrollService;
        }
        [HttpGet]
        [Route("GetIdPayroll/")]
        public IActionResult GetPayroll(int id)
        {
            var traking = _payrollService.GetPayroll(id);
            return Ok(traking);
        }
        [HttpGet]
        [Route("GetAllPayroll/")]
        public IActionResult GetPayroll()
        {
            var traking = _payrollService.GetPayrolls();
            return Ok(traking);
        }
        [HttpPost]
        [Route("PostPayroll/")]
        public async Task<IActionResult> CreatePayroll(PayrollRequest request)
        {
            var traking = await _payrollService.CreatePayroll(request);
            return Ok(traking);
        }
    }
}
