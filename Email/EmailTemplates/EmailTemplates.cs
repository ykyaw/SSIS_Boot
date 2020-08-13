﻿using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSIS_BOOT.Email.EmailTemplates
{
    public class EmailTemplates
    {
        public class delegatetemplate
        {
            public string name;
            public string email;
            public string body;
            public string subject = "New Delegate Request";
            public delegatetemplate(Employee u)
            {
                this.name = u.Name;
                this.email = u.Email;
                this.body =
                    "Dear " + u.Name + System.Environment.NewLine +
                    "A new Requisition form request was received, and pending your further action." + System.Environment.NewLine +
                    "Simply respond by clicking the link below to view the outstanding requisition list." + System.Environment.NewLine +
                    "www.google.com" + System.Environment.NewLine +
                    "Thank you";
            }
        }

        public class PRtemplate
        {
            public string name;
            public string email;
            public string body;
            public string subject = "New PR Request";
            public PRtemplate(Employee u)
            {
                this.name = u.Name;
                this.email = u.Email;
                this.body =
                    "Dear " + u.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "There are outstanding requisition forms that require your further action." + System.Environment.NewLine + System.Environment.NewLine +
                    "Simply respond by clicking the link below to view the outstanding requisition list." + System.Environment.NewLine + System.Environment.NewLine +
                    "https://www.youtube.com/" + System.Environment.NewLine + System.Environment.NewLine +
                    "Thank you";
            }
        }


        public class RequestQuoteTemplate
        {
            public string name;
            public string email;
            public string body;
            public string subject = "New Request for Quote";
            public RequestQuoteTemplate(Employee clerk, Employee u, List<PurchaseRequestDetail> req) 
            {
                StringBuilder builder = new StringBuilder();
                foreach (PurchaseRequestDetail r in req)
                {
                    builder.Append(r.Product.Description).Append(":").Append("  ").Append(r.ReorderQty).Append(System.Environment.NewLine); 
                }
                string result = builder.ToString();
                this.name = u.Name;
                this.email = u.Email;
                this.body =
                    "Dear " + u.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "We are looking to procure the following items: " + System.Environment.NewLine + System.Environment.NewLine +
                    result + System.Environment.NewLine +
                    "Please provide a quotation based on your existing stock and send to " + clerk.Email + "." + System.Environment.NewLine + System.Environment.NewLine +
                    "Thank you" + System.Environment.NewLine +
                    "Store Clerk " + clerk.Name;
            }
        }

    }
}