using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snap.Core.DTOs;
using Snap.Core.Repositories;

namespace Snap.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiModelController : ControllerBase
    {
        private readonly IAiModelService _aiService;

        public AiModelController(IAiModelService aiService)
        {
            _aiService = aiService;
        }


        /// <summary>
        /// POST /api/AiModel/predict
        /// Accepts a list of weight/calorie pairs and returns predicted weights.
        /// </summary>
        [HttpPost("predict")]
        [ProducesResponseType(typeof(PredictionResultDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Predict([FromBody] List<WeightCalorieRecordDto> input)
        {
            if (input == null || !input.Any())
                return BadRequest("At least one record is required.");

            var result = await _aiService.SendCsvAndGetResponseAsync(input);
            return Ok(result);
        }








    }
}
