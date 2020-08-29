using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SSIS_BOOT.Models;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace SSIS_BOOT.Email
{
    public class MailerImpl:IMailer
    {
        private readonly EmailSettings _emailSettings;
        public MailerImpl(IOptions<EmailSettings> _emailSettings)
        {
            this._emailSettings = _emailSettings.Value;
        }

        public async Task SendEmailAsync(EmailModel mailobj)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_emailSettings.Mail, _emailSettings.DisplayName);
            message.To.Add(new MailAddress(mailobj.emailTo));
            message.Subject = mailobj.emailSubject;
            message.IsBodyHtml = false;
            message.Body = mailobj.emailBody;
            smtp.Port = _emailSettings.Port;
            smtp.Host = _emailSettings.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_emailSettings.Mail, _emailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }

        public async Task SendRFQEmailAsync(EmailModel mailobj, Employee cc)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_emailSettings.Mail, _emailSettings.DisplayName);
            message.To.Add(new MailAddress(mailobj.emailTo));
            message.CC.Add(cc.Email);
            message.Subject = mailobj.emailSubject;
            message.IsBodyHtml = false;
            message.Body = mailobj.emailBody;
            smtp.Port = _emailSettings.Port;
            smtp.Host = _emailSettings.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_emailSettings.Mail, _emailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }

        public async Task SendEmailwithccAsync(EmailModel mailobj, Employee deptemp)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_emailSettings.Mail, _emailSettings.DisplayName);
            message.To.Add(new MailAddress(mailobj.emailTo));
            message.CC.Add(deptemp.Email);
            message.Subject = mailobj.emailSubject;
            message.IsBodyHtml = false;
            message.Body = mailobj.emailBody;
            smtp.Port = _emailSettings.Port;
            smtp.Host = _emailSettings.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_emailSettings.Mail, _emailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }

        public async Task SendEmailwithccallAsync(EmailModel mailobj, List<Employee> emplist)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_emailSettings.Mail, _emailSettings.DisplayName);
            message.To.Add(new MailAddress(mailobj.emailTo));
            foreach (Employee e in emplist)
            {
                message.CC.Add(e.Email);
            }
            message.Subject = mailobj.emailSubject;
            message.IsBodyHtml = false;
            message.Body = mailobj.emailBody;
            smtp.Port = _emailSettings.Port;
            smtp.Host = _emailSettings.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_emailSettings.Mail, _emailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }
    }
}
