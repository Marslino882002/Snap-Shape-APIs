using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snap.Core.About.Commands.Create;

namespace Snap.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController (IMediator mediator): ControllerBase
    {
        //[HttpPost]
        //public async Task<IActionResult> CreateAbout([FromQuery] CreateAboutCommand command)
        //{
        //    var response = await mediator.Send(command);
        //    return Ok(response);
        //}



        [HttpPost("save-about-details")]

        public async Task<IActionResult> SaveAboutDetails([FromBody] CreateAboutCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

       




    }
}
