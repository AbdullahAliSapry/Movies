using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;

namespace WebsiteMovies.WebServises
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            var fMail = "engineerabdallah67@gmail.com";
            var fPassword = "jjdwoqlbcnnyamwk";

            var theMSg = new MailMessage();
            theMSg.From = new MailAddress(fMail);

            theMSg.Subject = subject;
            theMSg.To.Add(new MailAddress(email));

            theMSg.Body = $"<html><body>{htmlMessage}</body></html>";
            theMSg.IsBodyHtml = true;

            var stmpClient = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fMail,fPassword),
                Port= 465,
            };

            stmpClient.Send(theMSg);
        }
    }
}
