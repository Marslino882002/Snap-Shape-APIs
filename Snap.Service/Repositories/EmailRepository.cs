using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using MimeKit;
using Snap.Core.Entities;
using Snap.Core.Repositories;
using Snap.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Service.Repositories
{
    public class EmailRepository(
       SnapDbContext dbContext ,
      UserManager<User> userManager  ) : IEmailRepository
    {
        public async Task<string> SendResetPassword(string Email)
        {



            try
            {
                var user = await userManager.FindByEmailAsync(Email);
                //user not Exist => not found
                if (user == null) { return "UserNotFound"; }

                Random random = new Random();

                string OTP = random.Next(0, 1000000).ToString("D6");

                user.OTP = OTP;
                var updateResult = await userManager.UpdateAsync(user);
                if (!updateResult.Succeeded) { return "Faild"; }
                var message = "Code To Reset Passsword : " + user.OTP;
                await SendEmail(user.Email, message, "ResetPassword");
                return "Success";
            }


            catch (Exception e) { return "Faild"; }







        }

        public async Task<string> SendEmail(string Email, string Message , string Reason)
        {

            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("Smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate("marssama306@gmail.com", "imkq cnzl kdny fcpu");
                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = $"{Message}",
                        TextBody = "wellcome",
                    };
                    var message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody()
                    };
                    message.From.Add(new MailboxAddress("Snap&Shape", "marssama306@gmail.com"));
                    message.To.Add(new MailboxAddress("testing", Email));
                    message.Subject = Reason;
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);

                }
                    return "Success";


            }

            catch (Exception e) { return "Faild"; }

        }

        public async  Task<string> ConfirmResetPassword(string Otp, string Email)
        {var user = await userManager.FindByEmailAsync(Email);
            //user not Exist => not found
            if (user == null) { return "UserNotFound"; }
            if (user.OTP == Otp){return "Success"; }
            return "Faild";}

        public async Task<string> ResetPassword(string Email, string NewPassword)
        {
            try {var user = await userManager.FindByEmailAsync(Email);
                    //user not Exist => not found
                    if (user == null) { return "UserNotFound"; }

                    await userManager.RemovePasswordAsync(user);

                    await userManager.AddPasswordAsync(user , NewPassword);
                await SendEmail(user.Email, "We want to inform you that your password has been reset successfully. If you made this change, no further action is required.\r\n\r\nIf you did not request this change, please contact our support team immediately to secure your account.", "Your Password Has Been Reset Successfully");
                return "Success";} 
                catch (Exception e) { return "Faild"; }








        }
    }
    }

