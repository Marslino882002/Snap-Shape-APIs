using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snap.Core.Email.Commands.ConfirmResetPassword;
using Snap.Core.Email.Commands.ResetPassword;
using Snap.Core.Email.Commands.SendEmail;

namespace Snap.APIs.Controllers
{
    [AllowAnonymous]

    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class EmailController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Send-Email")]
        public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }


        [HttpPost("Send-OTP to Reset-Password")]
        public async Task<IActionResult> SendResetPassword([FromQuery] SendResetPasswordCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }



        [HttpGet("Confirm-Reset Password")]
        public async Task<IActionResult> ConfirmResetPassword([FromQuery] ConfirmResetPasswordCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }


        [HttpPost("Change-Password")]
        public async Task<IActionResult>ResetPassword([FromForm]ResetPasswordCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }




    }
}
