using Microsoft.VisualBasic;
using SSIS_BOOT.Models;
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
            public string body;
            public string subject = "New Request for Quote from LU Staionary Store";
            public RequestQuoteTemplate(Employee clerk, Supplier S, List<PurchaseRequestDetail> req)
            {
                StringBuilder builder = new StringBuilder();
                foreach (PurchaseRequestDetail r in req)
                {
                    builder.Append(r.Product.Description).Append(":").Append("  ").Append(r.ReorderQty).Append(System.Environment.NewLine);
                }
                string result = builder.ToString();
                this.name = S.Name;
                this.body =
                    "Dear " + S.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "We are looking to procure the following items: " + System.Environment.NewLine + System.Environment.NewLine +
                    result + System.Environment.NewLine +
                    "Please provide a quotation based on your existing stock and send to " + clerk.Email + "." + System.Environment.NewLine + System.Environment.NewLine +
                    "Thank you" + System.Environment.NewLine +
                    "Store Clerk " + clerk.Name;
            }
        }

        public class CollectionTimeTemplate
        {
            public string name;
            public string body;
            public string subject = "Requistion scheduled for collection";
            public CollectionTimeTemplate(Requisition r1,Employee drep)
            {
                long createddate = r1.CreatedDate;
                long collectiondate = (long) r1.CollectionDate;
                
                DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                DateTime createddate1 = startTime.AddMilliseconds(Convert.ToDouble(createddate));
                DateTime collectiondate1 = startTime.AddMilliseconds(Convert.ToDouble(collectiondate));
                string createddate2 = createddate1.ToString("dd MMM yyyy");
                string collectiondate2 = collectiondate1.ToString("dd MMM yyyy");

                this.body =
                    "Dear " + drep.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "The requisition form submitted by " + r1.ReqByEmp.Name + " dated " + createddate2 + System.Environment.NewLine
                    + "has been scheduled for collection on " + collectiondate2 + " at " + r1.CollectionPoint.Location + "."
                    +System.Environment.NewLine +System.Environment.NewLine +
                    "Thank you." + System.Environment.NewLine + System.Environment.NewLine +
                    "Store Clerk " + System.Environment.NewLine + r1.ProcessedByClerk.Name;
            }
        }
        public class AckCompletedReq
        {
            public string name;
            public string body;
            public string subject = "";
            public AckCompletedReq(List<Requisition> reqlist, Employee drep)
            {         
                long ReceivedDate = (long)reqlist[0].ReceivedDate;
                DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                DateTime ReceivedDate1 = startTime.AddMilliseconds(Convert.ToDouble(ReceivedDate));
                string ReceivedDate2 = ReceivedDate1.ToString("dd MMM yyyy");

                StringBuilder builder = new StringBuilder();
                foreach (Requisition r in reqlist)
                {
                    builder.Append(r.Id).Append(":").Append("  ").Append(r.ReqByEmp.Name).Append(System.Environment.NewLine);
                }
                string result = builder.ToString();
                this.subject = "List of requisitions completed on " + ReceivedDate2 + " for department:" + reqlist[0].Department.Name + ".";

                this.body =
                    "Dear " + drep.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "The following requisitions for " + drep.Department.Name + "has been completed on " + ReceivedDate2 + "." + System.Environment.NewLine
                    + "Kindly refer to the list below:"
                    + System.Environment.NewLine + System.Environment.NewLine
                    + result
                    + System.Environment.NewLine + System.Environment.NewLine +
                     "Thank you.";
            }
        }

        public class UpdatePRStatusTemplate
        {
            public string name;
            public string body;
            public string subject = "Purchase request pending for approval";
            public UpdatePRStatusTemplate(List<PurchaseRequestDetail> updatedprlist, Employee sup)
            {
                this.body =
                    "Dear " + sup.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "A new purchase request was received, pending your further action." + System.Environment.NewLine + System.Environment.NewLine+
                    "Simply respond by clicking here to view the outstanding purchase request."
                    + System.Environment.NewLine + System.Environment.NewLine +
                    "Thank you." + System.Environment.NewLine + System.Environment.NewLine +
                   "Store Clerk " + System.Environment.NewLine + updatedprlist[0].CreatedByClerk.Name;
                // pending the link for sup to access outstanding pr.

            }
        }







        //for store supervisor to send out email on approved PR
        // create a new class
        //public ApprovePOtemplate(Employee clerk, Supplier S, PurchaseOrder po)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    foreach (PurchaseOrderDetail r in po.PurchaseOrderDetails.ToList())
        //    {
        //        builder.Append(r.Product.Description).Append(":").Append("  ").Append(r.QtyPurchased).Append(System.Environment.NewLine);
        //    }
        //    string result = builder.ToString();
        //    this.name = S.Name;
        //    this.body =
        //        "Dear " + S.Name + System.Environment.NewLine + System.Environment.NewLine +
        //        "Please supply the following items:" + System.Environment.NewLine + System.Environment.NewLine +
        //        result + System.Environment.NewLine +
        //        "Please provide a quotation based on your existing stock and send to " + clerk.Email + "." + System.Environment.NewLine + System.Environment.NewLine +
        //        "Thank you" + System.Environment.NewLine +
        //        "Store Clerk " + clerk.Name;
        //}


    }
}
