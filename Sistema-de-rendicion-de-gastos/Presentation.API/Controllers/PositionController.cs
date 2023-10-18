using Application.DTO.Request;
using Application.Interfaces.IServices;
using Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        [HttpGet]
        [Route("GetIdPosition/")]
        public IActionResult GetPosition(int id)
        {
            var traking = _positionService.GetPosition(id);
            return Ok(traking);
        }
        [HttpGet]
        [Route("GetAllPosition/")]
        public IActionResult GetPosition()
        {
            var traking = _positionService.GetPositions();
            return Ok(traking);
        }
        
        [HttpPost]
        [Route("PostPosition/")]
        public async Task<IActionResult> CreatePosition(PositionRequest request)
        {
            var traking = await _positionService.CreatePosition(request);
            return Ok(traking);
        }


    }
}
