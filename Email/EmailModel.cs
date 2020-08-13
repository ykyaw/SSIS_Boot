using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Email
{
    public class EmailModel
    {
        public string emailTo { get; set; }
        public string emailSubject { get; set; }
        public string emailBody { get; set; }
    }
}
