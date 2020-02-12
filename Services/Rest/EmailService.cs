using Core.Services.Rest;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Rest
{
    public class EmailService : IEmailService
    {
        public async Task Send(string toEmail, string toName, string templateId, object data)
        {
            var client = new SendGridClient("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");

            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom("eaghayevv@gmail.com", "Test title");
            sendGridMessage.AddTo(toEmail, toName);

            sendGridMessage.SetTemplateId(templateId);
            sendGridMessage.SetTemplateData(data);

            await client.SendEmailAsync(sendGridMessage);
        }
    }
}
