using MediatR;
using Snap.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Email.Commands.ResetPassword
{
    public class SendResetPasswordCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }

        

    }
}
