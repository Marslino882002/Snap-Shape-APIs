using MediatR;
using Snap.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Email.Commands.ConfirmResetPassword
{
    public class ConfirmResetPasswordCommand : IRequest<Response<string>>

    {

        public string Code { get; set; }

        public string Email { get; set; }




    }
}
