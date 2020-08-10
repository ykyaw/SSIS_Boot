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

        public virtual Employee InitiatedClerk { get; set; }
        public virtual Employee ApprovedSup { get; set; }
        public virtual Employee ApprovedMgr { get; set; }
        public virtual List<AdjustmentVoucherDetail> AdjustmentVoucherDetails { get; set; }
    }
}
