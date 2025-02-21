using FluentValidation;
using Snap.Core.Email.Commands.SendEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Email.Commands.ResetPassword
{
    public class SendResetPasswordValidator : AbstractValidator<SendResetPasswordCommand>
    {


        public SendResetPasswordValidator()
        {
            ApplyValidationRules();

        }

        private void ApplyValidationRules()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Recipient email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
