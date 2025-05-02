using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Snap.APIs.Errors;
using Snap.Core.About.Commands.Create;

namespace Snap.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController (IMediator _mediator): ControllerBase
    {

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAbout( CreateAboutCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            // Send the command to MediatR and await the result
            var result = await _mediator.Send(command);

            if (result <= 0)
            {
                return Unauthorized(new { message = "You are not authorized to perform this action." });
            }

            return Ok(new { Id = result });
        }





    }
}
