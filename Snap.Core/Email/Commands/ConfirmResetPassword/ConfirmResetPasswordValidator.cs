using FluentValidation;
using Snap.Core.Email.Commands.ResetPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Email.Commands.ConfirmResetPassword
{
    internal class ConfirmResetPasswordValidator : AbstractValidator<ConfirmResetPasswordCommand>
    {


        public ConfirmResetPasswordValidator()
        {
            ApplyValidationRules();

        }

        private void ApplyValidationRules()
        {
            RuleFor(x => x.Code)
            .NotEmpty().WithMessage("OTP Code is required.");

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Recipient email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        }
    }
    
    }
