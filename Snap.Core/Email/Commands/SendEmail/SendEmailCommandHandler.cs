using MediatR;
using Snap.Core.Common;
using Snap.Core.Email.Commands.SendEmail;
using Snap.Core.Repositories;

public class SendEmailCommandHandler(
    IEmailRepository emailRepository)
    : ResponseHandler, IRequestHandler<SendEmailCommand, Response<string>>
{
    public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        // Validate inputs
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Message))
        {
            return BadRequest<string>("Email and Message are required.");
        }

        // Provide a default subject if null
        var subject = request.Reason ?? "No Subject Provided";

        // Attempt to send the email
        var response = await emailRepository.SendEmail(request.Email, request.Message, subject);

        // Check response and return appropriate result
        return response == "Success"
            ? Success<string>("Email sent successfully")
            : BadRequest<string>($"Failed to send email: {response}");
    }
}
