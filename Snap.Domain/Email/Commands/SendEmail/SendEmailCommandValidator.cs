using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Email.Commands.SendEmail
{
    internal class SendEmailCommandValidator : AbstractValidator<SendEmailCommand>
    {
        public SendEmailCommandValidator()
        {
            ApplyValidationRules();
        }

        private void ApplyValidationRules()
        {
            RuleFor(x => x.Email)
                            .NotEmpty().WithMessage("Recipient email is required.")
                            .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Email subject is required.");
        }
    
    }
}
