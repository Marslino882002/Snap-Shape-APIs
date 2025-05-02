using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snap.Core.DTOs;
using Snap.Core.ScrapedProducts.Commands.ScrapeHealthyProducts;
using Snap.Core.ScrapedProducts.Queries;

namespace Snap.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapedProductsController(IMediator _mediator) : ControllerBase
    {




        // POST api/ScrapedProducts/scrape
        [HttpPost("scrape")]
        public async Task<ActionResult<ScrapedProductDto>> Scrape([FromBody] ScrapeHealthyProductsCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.CategoryUrl))
                return BadRequest("CategoryUrl is required.");

            var count = await _mediator.Send(command);
            var products = await _mediator.Send(new GetScrapedProductsQuery());

            return Ok();
        }




        // GET api/ScrapedProducts
        [HttpGet]
        public async Task<ActionResult<List<ScrapedProductDto>>> GetAll()
        {
            var products = await _mediator.Send(new GetScrapedProductsQuery());
            return Ok(products);
        }








    }
}
