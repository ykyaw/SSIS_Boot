using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Common
{
    public class Status
    {
        public static class AdjVoucherStatus
        {
            public const string created = "Created";
            public const string pendapprov = "Pending Approval"; //upon creation, but not approved by anyone
            public const string pendmanapprov = "Pending Manager Approval"; //if anything more than $250, and has been approved by supervisor but not yet approved by manager
            public const string approved = "Approved"; // if anything <250 and approved by supervisor, OR if anything more >250 and both supervisor and manager approved 
            public const string rejected = "Rejected";
        }

        public static class RequsitionStatus
        {
            public const string created = "Created"; //upon creation before approval
            public const string pendapprov = "Pending Approval"; //after submit for approval
            public const string approved = "Approved"; // after approved, before clerk enters a disbursement time
            public const string rejected = "Rejected";
            public const string confirmed = "Confirmed"; //after approved, and after clerk entered a disbursement time
            public const string received = "Received"; // after department rep received at collection point, and pressed the button to indicate he received. This will trigger the button for clerk to click acknowledged
            public const string completed = "Completed"; //after clerk click acknowledged, requsition status is completed
        }

        public static class RetrievalStatus
        {
            public const string created = "Created"; //upon creation of retrieval form
            public const string retrieved = "Retrieved"; //after clicking retrieved
        }

        public static class PurchaseRequestStatus
        {
            public const string created = "Created"; //upon creation before approval
            public const string pendapprov = "Pending Approval"; //after submit for approval
            public const string rejected = "Rejected";
            public const string approved = "Approved";
        }

        //public static class PurchaseOrderDetailStatus //Previous status
        //{
        //    public const string approved = "Approved";
        //    public const string received = "Received"; //received from supplier
        //}

        public static class PurchaseOrderDetailStatus
        {
            public const string pending = "Pending Delivery"; //initial status upon creation
            public const string received = "Received"; //received from supplier
        }
        public static class PurchaseOrderStatus
        {
            public const string pending = "Pending Delivery"; //When >1 PurchaseOrderDetail is still pending delivery
            public const string completed = "Completed"; //When all PurchaseOrderDetail is received
        }
    }
}
