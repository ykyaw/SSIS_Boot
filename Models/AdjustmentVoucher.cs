using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class AdjustmentVoucher
    {
        [Key]
        public string Id { get; set; }
        public int InitiatedClerkId { get; set; }
        public long InitiatedDate { get; set; }
        public int? ApprovedSupId { get; set; }
        public long? ApprovedSupDate { get; set; }
        public int? ApprovedMgrId { get; set; }
        public long? ApprovedMgrDate { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }

        public  Employee InitiatedClerk { get; set; }
        public  Employee ApprovedSup { get; set; }
        public  Employee ApprovedMgr { get; set; }
        public  List<AdjustmentVoucherDetail> AdjustmentVoucherDetails { get; set; }

        //constructor
        public AdjustmentVoucher(){ }
        public AdjustmentVoucher(string Id, int InitiatedClerkId, long InitiatedDate, string Status) {
            this.Id = Id;
            this.InitiatedClerkId = InitiatedClerkId;
            this.InitiatedDate = InitiatedDate;
            this.Status = Status;
        }

        public AdjustmentVoucher(string Id, int InitiatedClerkId, long InitiatedDate,
            int? ApprovedSupId, long? ApprovedSupDate, string Status) {
                this.Id = Id;
                this.InitiatedClerkId = InitiatedClerkId;
                this.InitiatedDate = InitiatedDate;
                this.ApprovedSupId = ApprovedSupId;
                this.ApprovedSupDate = ApprovedSupDate;
                this.Status = Status;
            }
        public AdjustmentVoucher(string Id, int InitiatedClerkId, long InitiatedDate, 
            int? ApprovedSupId, long? ApprovedSupDate, int? ApprovedMgrId, long? ApprovedMgrDate, string Status) {
            this.Id = Id;
            this.InitiatedClerkId = InitiatedClerkId;
            this.InitiatedDate = InitiatedDate;
            this.ApprovedSupId = ApprovedSupId;
            this.ApprovedSupDate = ApprovedSupDate;
            this.ApprovedMgrId = ApprovedMgrId;
            this.ApprovedMgrDate = ApprovedMgrDate;
            this.Status = Status;
        }

    }
}
