using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Email
{
    public interface IMailer
    {
        Task SendEmailAsync(EmailModel mailobj);
        Task SendRFQEmailAsync(EmailModel mailobj, Employee cc);

        Task SendEmailwithccAsync(EmailModel mailobj, Employee deptemp);
    }
}
