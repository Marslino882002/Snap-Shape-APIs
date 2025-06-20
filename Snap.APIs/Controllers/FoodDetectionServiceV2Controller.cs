using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snap.Core.DTOs;
using Snap.Core.Repositories;

namespace Snap.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodDetectionServiceV2Controller : ControllerBase
    {

        private readonly IFoodDetectionServiceV2 _foodDetectionService;

        public FoodDetectionServiceV2Controller(IFoodDetectionServiceV2 foodDetectionService)
        {
            _foodDetectionService = foodDetectionService;
        }

        [HttpPost("detect")]
        public async Task<IActionResult> DetectFood([FromForm] FileUploadDto dto)
        {
            if (dto.File == null || dto.File.Length == 0)
                return BadRequest("Image file is required.");

            var result = await _foodDetectionService.DetectAsync(dto.File);
            return Ok(result);
        }







    }
}
