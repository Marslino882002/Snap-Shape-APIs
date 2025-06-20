using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snap.Core.DTOs;
using Snap.Core.Entities;
using Snap.Core.Repositories;
using Snap.Core.ScrapedProducts.Commands.ScrapeHealthyProducts;
using Snap.Core.ScrapedProducts.Queries;

namespace Snap.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapedProductsController(IScrapedProductRepository repository) : ControllerBase
    {




        // POST api/ScrapedProducts/scrape
        //[HttpPost("scrape")]
        //public async Task<ActionResult<ScrapedProductDto>> Scrape([FromBody] ScrapeHealthyProductsCommand command)
        //{
        //    if (string.IsNullOrWhiteSpace(command.CategoryUrl))
        //        return BadRequest("CategoryUrl is required.");

        //    var count = await _mediator.Send(command);
        //    var products = await _mediator.Send(new GetScrapedProductsQuery());

        //    return Ok();
        //}




        //// GET api/ScrapedProducts
        //[HttpGet]
        //public async Task<ActionResult<List<ScrapedProductDto>>> GetAll()
        //{
        //    var products = await _mediator.Send(new GetScrapedProductsQuery());
        //    return Ok(products);
        //}



        /// <summary>
        /// Get all scraped products from the database.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<ScrapedProduct>>> GetAll()
        {
            var products = await repository.GetAllAsync();
            return Ok(products);
        }

        /// <summary>
        /// Scrape products from the given iHerb category URL and save them to the database.
        /// </summary>
        /// <param name="categoryUrl">URL to scrape</param>
        [HttpPost("scrape")]
        public async Task<IActionResult> ScrapeProducts([FromQuery] string categoryUrl)
        {
            if (string.IsNullOrWhiteSpace(categoryUrl))
                return BadRequest("Category URL is required.");

            var scrapedProducts = await repository.ScrapeFromUrlAsync(categoryUrl);

            if (!scrapedProducts.Any())
                return NotFound("No products found on the page.");

            await repository.AddRangeAsync(scrapedProducts);

            return Ok(new
            {
                Message = "Scraping completed successfully.",
                TotalSaved = scrapedProducts.Count
            });
        }








    }
}