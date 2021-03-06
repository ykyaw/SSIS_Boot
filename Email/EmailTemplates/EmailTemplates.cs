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
                    "http://localhost:51118/" + System.Environment.NewLine + System.Environment.NewLine +
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
            public CollectionTimeTemplate(Requisition r1, Employee drep)
            {
                long createddate = r1.CreatedDate;
                long collectiondate = (long)r1.CollectionDate;

                DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                DateTime createddate1 = startTime.AddMilliseconds(Convert.ToDouble(createddate));
                DateTime collectiondate1 = startTime.AddMilliseconds(Convert.ToDouble(collectiondate));
                string createddate2 = createddate1.ToString("dd MMM yyyy");
                string collectiondate2 = collectiondate1.ToString("dd MMM yyyy");

                this.body =
                    "Dear " + drep.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "The requisition form submitted by " + r1.ReqByEmp.Name + " dated " + createddate2 + System.Environment.NewLine
                    + "has been scheduled for collection on " + collectiondate2 + " at " + r1.CollectionPoint.Location + "."
                    + System.Environment.NewLine + System.Environment.NewLine +
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
                DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
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
                    "A new purchase request was received, pending your further action." + System.Environment.NewLine + System.Environment.NewLine +
                    "Please log in to the LU Stationary Portal in the link below to access them."
                    + System.Environment.NewLine + System.Environment.NewLine +
                    "http://localhost:51118/"
                    + System.Environment.NewLine + System.Environment.NewLine +
                    "Thank you." + System.Environment.NewLine + System.Environment.NewLine +
                   "Store Clerk " + System.Environment.NewLine + updatedprlist[0].CreatedByClerk.Name;
            }
        }
        public class SubmitAV
        {
            public string name;
            public string body;
            public string subject = "Adjustment Voucher pending for approval";
            public SubmitAV(Employee sup, Employee clerk)
            {
                this.body =
                    "Dear " + sup.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "A new adjustment voucher was received, pending your further action." + System.Environment.NewLine + System.Environment.NewLine +
                    "Please log in to the LU Stationary Portal in the link below to access them."
                    + System.Environment.NewLine + System.Environment.NewLine +
                    "http://localhost:51118/"
                    + System.Environment.NewLine + System.Environment.NewLine +
                    "Thank you." + System.Environment.NewLine + System.Environment.NewLine +
                   "Store Clerk " + System.Environment.NewLine + clerk.Name;
            }
        }

        public class SubmitreqformTemplate
        {
            public string name;
            public string body;
            public string subject = "Requisition form pending for approval";
            public SubmitreqformTemplate(Requisition req, Employee approvedBy, Employee deptemp)
            {
                this.body =
                    "Dear " + approvedBy.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "A new requisition form was received, pending your further action." + System.Environment.NewLine + System.Environment.NewLine +
                    "Please log in to the LU Stationary Portal in the link below to access them."
                    + System.Environment.NewLine + System.Environment.NewLine +
                    "http://localhost:51118/"
                    + System.Environment.NewLine + System.Environment.NewLine +
                    "Thank you." + System.Environment.NewLine + System.Environment.NewLine +
                   "Department Employee" + System.Environment.NewLine + deptemp.Name;
            }
        }
        public class ProcessedreqTemplate
        {
            public string name;
            public string body;
            public string subject = "Outcome of requisition form submitted";
            public ProcessedreqTemplate(Requisition req, Employee deptemp, Employee Approvedby)
            {
                long createdate = req.CreatedDate;
                DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                DateTime createdate1 = startTime.AddMilliseconds(Convert.ToDouble(createdate));
                string createdate2 = createdate1.ToString("dd MMM yyyy");


                if (req.Remarks == null)
                {
                    this.body =
                    "Dear " + deptemp.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "Your requisition form created on " + req.CreatedDate + System.Environment.NewLine + System.Environment.NewLine +
                    "has been " + req.Status + ". "
                    + System.Environment.NewLine + System.Environment.NewLine +
                    "Thank you." + System.Environment.NewLine + System.Environment.NewLine +
                    Approvedby.Name;
                }
                else
                {
                    this.body =
                   "Dear " + deptemp.Name + System.Environment.NewLine + System.Environment.NewLine +
                   "Your requisition form created on " + createdate2 + System.Environment.NewLine + System.Environment.NewLine +
                   "has been " + req.Status + ". The reason stated is " + req.Remarks + "."
                   + System.Environment.NewLine + System.Environment.NewLine +
                   "Thank you." + System.Environment.NewLine + System.Environment.NewLine +
                   Approvedby.Name;
                }
            }
        }
        public class AssignDelTemplate
        {
            public string name;
            public string body;
            public string subject = "";
            public AssignDelTemplate(Employee delegateemp, Employee depthead)
            {
                long delegatestartdate = (long)delegateemp.DelegateFromDate;
                DateTime startTime = new DateTime (1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                DateTime delegatestartdate1 = startTime.AddMilliseconds(Convert.ToDouble(delegatestartdate));
                string delegatestartdate2 = delegatestartdate1.ToString("dd MMM yyyy");

                long delegateenddate = (long)delegateemp.DelegateToDate;
                DateTime delegateenddate1 = startTime.AddMilliseconds(Convert.ToDouble(delegateenddate));
                string delegateenddate2 = delegateenddate1.ToString("dd MMM yyyy");

                this.subject = "Delegation of stationery approval for " + depthead.Department.Name;

                this.body =
               "Dear " + delegateemp.Name + System.Environment.NewLine + System.Environment.NewLine +
               "I will be unavailable from " + delegatestartdate2 + " to " + delegateenddate2 + "." + System.Environment.NewLine + System.Environment.NewLine +
               "The process of requisition approval has been assigned to you."
               + System.Environment.NewLine + System.Environment.NewLine +
               "Thank you." + System.Environment.NewLine + System.Environment.NewLine +
                "Department Head" + System.Environment.NewLine + depthead.Name;
            }
        }

        public class AssignDeptRepTemplate
        {
            public string name;
            public string body;
            public string subject = "";
            public AssignDeptRepTemplate(Employee deptrep, Employee depthead, CollectionPoint cp)
            {

                this.subject = "Assigning of Department Representative for " + depthead.Department.Name;
                this.body =
               "Dear " + deptrep.Name + System.Environment.NewLine + System.Environment.NewLine +
               "You have been assigned as the department representative for " + depthead.Department.Name + ". The current collection point is set at " + cp.Location + "."
               + System.Environment.NewLine + System.Environment.NewLine +
               "Thank you." + System.Environment.NewLine + System.Environment.NewLine +
               "Department Head" + System.Environment.NewLine + depthead.Name;
            }
        }

        public class ApprovedPRtemplate
        {
            public string name;
            public string body;
            public string subject = "New Purchase order for processing from Lu Stationery Store";
            public ApprovedPRtemplate(Employee clerk, Supplier sup, List<PurchaseOrderDetail> podlist, PurchaseOrder po)
            {
                string x = "";
                for (int i = 0; i < 84; i++)
                {
                    x += "-";
                }
                x += "\n";
                foreach (PurchaseOrderDetail pod in podlist)
                {
                    x += "Your Quotation Number: ";
                    x += pod.PurchaseRequestDetail.VenderQuote + "\n";
                    x += "ProductID: ";
                    x += pod.ProductId + "\n";
                    x += "Product Description: ";
                    x += pod.Product.Description + "\n";
                    x += "Quantity: ";
                    x += pod.QtyPurchased + "\n";
                    x += "Total Price: ";
                    x += string.Format("{0,0:C}", pod.TotalPrice) + "\n";
                    for (int i = 0; i < 84; i++)
                    {
                        x += "-";
                    }
                    x += "\n";
                }
                long supplybydate = (long)po.SupplyByDate;
                DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                DateTime supplybydate1 = startTime.AddMilliseconds(Convert.ToDouble(supplybydate));
                string supplybydate2 = supplybydate1.ToString("dd MMM yyyy");               
                DateTime orderdate1 = startTime.AddMilliseconds(Convert.ToDouble((long)po.OrderedDate));
                string ordereddate2 = orderdate1.ToString("dd MMM yyyy");

                this.body =
               "Dear " + sup.ContactPersonName + System.Environment.NewLine + System.Environment.NewLine +
               "Kindly refer to the LU Stationery Store purchase order # " + '"'+po.Id+'"' + " dated " + ordereddate2 + "."
               + System.Environment.NewLine + System.Environment.NewLine
               + x + System.Environment.NewLine + System.Environment.NewLine
               + "Please supply the above items by " + supplybydate2 + "."
               + " If there are any concerns, please contact " + clerk.Name + "(" + clerk.Email+")."
               + System.Environment.NewLine + System.Environment.NewLine +
               "Thank you." + System.Environment.NewLine + System.Environment.NewLine +
               "LU Stationery Store";

            }
        }

        public class RejectedPRtemplate
        {
            public string name;
            public string body;
            public string subject = "Your purchase request has been rejected";
            public RejectedPRtemplate(Employee clerk, Employee supervisor, int prid, long submitdate, string remarks)
            {
                if (remarks == null)
                {
                    this.body =
                     "Dear " + clerk.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "Your purchase request with id:" + prid + " dated " + submitdate + " has been rejected by the store supervisor."
                     + System.Environment.NewLine + System.Environment.NewLine +
                    "Thank you." + System.Environment.NewLine + System.Environment.NewLine +
                    "Store supervisor" + System.Environment.NewLine + supervisor.Name;
                }
                else
                {
                    this.body =
                     "Dear " + clerk.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "Your purchase request with id:" + prid + " dated " + submitdate + " has been rejected by the store supervisor. The reason stated is "+remarks+"."
                     + System.Environment.NewLine + System.Environment.NewLine +
                    "Thank you." + System.Environment.NewLine + System.Environment.NewLine +
                    "Store supervisor" + System.Environment.NewLine + supervisor.Name;
                }
            }
        }
        public class PendingManagerApprovalAVTemplate
        {
            public string name;
            public string body;
            public string subject = "Adjustment Voucher pending for manager approval";
            public PendingManagerApprovalAVTemplate(AdjustmentVoucher av, Employee manager,Employee sup)
            {
                long InitiatedDate = (long)av.InitiatedDate;
                DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                DateTime InitiatedDate1 = startTime.AddMilliseconds(Convert.ToDouble(InitiatedDate));
                string InitiatedDate2 = InitiatedDate1.ToString("dd MMM yyyy");
                if (av.Reason == null)
                {
                    this.body =
                     "Dear " + manager.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "A new adjustment voucher submitted on "+ InitiatedDate2 + " is pending your further action." + System.Environment.NewLine + System.Environment.NewLine +
                    "Thank you." + System.Environment.NewLine + System.Environment.NewLine +
                    "Store supervisor" + System.Environment.NewLine + sup.Name;
                }
                else
                {
                    this.body =
                     "Dear " + manager.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "A new adjustment voucher submitted on " + InitiatedDate2 + " is pending your further action. The reason provided by the supervisor is " + av.Reason + "."
                     + System.Environment.NewLine + System.Environment.NewLine +
                    "Thank you." + System.Environment.NewLine + System.Environment.NewLine +
                    "Store supervisor" + System.Environment.NewLine + sup.Name;
                }
            }
        }

        public class ApproveRejectAVTemplate
        {
            public string name;
            public string body;
            public string subject = "Outcome of Adjustment Voucher";
            public ApproveRejectAVTemplate(AdjustmentVoucher av, Employee clerk, Employee sup)
            {
                long InitiatedDate = (long)av.InitiatedDate;
                DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                DateTime InitiatedDate1 = startTime.AddMilliseconds(Convert.ToDouble(InitiatedDate));
                string InitiatedDate2 = InitiatedDate1.ToString("dd MMM yyyy");
               
                if (av.Reason == null)
                {
                    this.body =
                     "Dear " + clerk.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "Your adjustment voucher with id: " + av.Id + " dated " + InitiatedDate2 + " is " + av.Status + "." +
                    System.Environment.NewLine + System.Environment.NewLine +
                    "Thank you.";
                }
                else
                {
                    this.body =
                     "Dear " + clerk.Name + System.Environment.NewLine + System.Environment.NewLine +
                    "Your adjustment voucher with id: " + av.Id + " dated " + InitiatedDate2 + " is " + av.Status +
                    ". The reason provided is " + av.Reason + "."
                     + System.Environment.NewLine + System.Environment.NewLine +
                    "Thank you.";
                }
            }
        }

    }
}
