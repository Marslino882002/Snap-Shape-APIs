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



        [HttpGet("predict-weight")]
        public async Task<ActionResult<PredictionResultDto>> GetPredictedWeight()
        {
            var result = new PredictionResultDto
            {
                PredictedWeight = new List<double>
            {
                107.61966705322266,
                107.42593383789062,
                107.20130920410156,
                106.94723510742188,
                106.82571411132812,
                106.70574951171875,
                106.56610870361328
            }
            };

            return Ok(await Task.FromResult(result));
        }




    }
}
