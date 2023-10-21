using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces.IServices;
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
        [Route("Position/{id}")]
        [ProducesResponseType(typeof(PositionResponse), 200)]

        public async Task<IActionResult> GetPosition(int id)
        {
            var result = await _positionService.GetPosition(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllPosition/")]
        [ProducesResponseType(typeof(List<PositionResponse>), 200)]
        public async Task<IActionResult> GetPosition()
        {
            var result = await _positionService.GetPositions();

            return Ok(result);
        }
        
        [HttpPost]
        [Route("Create/")]
        public async Task<IActionResult> CreatePosition([FromBody] PositionRequest request)
        {
            var result = await _positionService.CreatePosition(request);
            return Ok(result);
        }
    }
}
