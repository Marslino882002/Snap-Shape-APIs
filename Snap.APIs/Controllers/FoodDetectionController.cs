using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snap.Core.DTOs;
using Snap.Core.Repositories;

namespace Snap.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodDetectionController : ControllerBase
    {

        private readonly IFoodDetectionService _foodDetectionService;

        public FoodDetectionController(IFoodDetectionService foodDetectionService)
        {
            _foodDetectionService = foodDetectionService;
        }



        /// <summary>
        /// Detects food objects and checks freshness from an uploaded image.
        /// </summary>
        /// <param name="file">Image file (JPG/PNG/WEBP)</param>
        /// <returns>Detected food items and their freshness status</returns>
        [HttpPost("detect")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<FoodDetectionResultDto>> DetectFood([FromForm] FileUploadDto dto)
        {
            if (dto.File == null || dto.File.Length == 0)
                return BadRequest("No file uploaded.");

            var result = await _foodDetectionService.DetectAsync(dto.File);
            return Ok(result);
        }

    }
}
