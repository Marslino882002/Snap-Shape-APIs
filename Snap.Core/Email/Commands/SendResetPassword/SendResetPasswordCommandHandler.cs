using MediatR;
using Snap.Core.Common;
using Snap.Core.Email.Commands.SendEmail;
using Snap.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Email.Commands.ResetPassword
{
    public class SendResetPasswordCommandHandler(IEmailRepository emailrepo) : ResponseHandler, IRequestHandler<SendResetPasswordCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(SendResetPasswordCommand request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest<string>("Invalid email address.");
            }

            var result = await emailrepo.SendResetPassword(request.Email);


            switch (result)
            {




                case "UserNotFound":
                    return BadRequest<string>("The user was not found.");

                case "ErrorInUpdateUser":
                    return BadRequest<string>("Error updating user.");

                case "Failed":
                    return BadRequest<string>("Operation failed.");

                case "Success":
                    return Success<string>("Password reset email sent successfully."); // ✅ Correct success response

                default:
                    return BadRequest<string>("Invalid response from the server.");

            }





            



        }
    }
}
