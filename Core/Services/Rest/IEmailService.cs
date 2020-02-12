using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Rest
{
    public interface IEmailService
    {
        Task Send(string toEmail, string toName, string templateId, object data);
    }
}
