using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GestionFacturation.Api.Services
{
    public class SendGridAPI
    {
        public static async Task<bool> Execute(string userEmail, string userName, string plainTextContent,
            string htmlContent, string subject)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("khtatbadoha@gmail.com", "doha");
            var to = new EmailAddress(userEmail, userName);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return await Task.FromResult(true);
        }
    }
}
