using MediatR;
using Snap.Core.Common;
using Snap.Core.Email.Commands.ConfirmResetPassword;
using Snap.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Email.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler(IEmailRepository emailrepo)
        : ResponseHandler, IRequestHandler<ResetPasswordCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest<string>("Invalid email address.");
            }

            var result = await emailrepo.ResetPassword(request.Email, request.NewPassword  );


            switch (result)
            {
                case "UserNotFound":
                    return BadRequest<string>("The user was not found.");

                case "ErrorInUpdateUser":
                    return BadRequest<string>("Error updating user.");

                case "Failed":
                    return BadRequest<string>("Operation failed.");

                case "Success":
                    return Success<string>("Password reset email sent successfully.");
                default:
                    return BadRequest<string>("Invalid response from the server.");

            }




        }
    }
}
