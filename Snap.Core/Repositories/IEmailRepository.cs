using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Repositories
{
    public interface IEmailRepository
    {
        public Task<string> SendEmail(string Email, string Message, string Reason);
        public Task<string> SendResetPassword(string Email);
        public Task<string> ConfirmResetPassword (string Otp , string Email);
        public Task<string> ResetPassword(string Email , string NewPassword );





    }

}
