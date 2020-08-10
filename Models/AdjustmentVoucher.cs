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
        [Required]
        public int InitiatedClerkId { get; set; }
        [Required]
        public long InitiatedDate { get; set; }
        public int? ApprovedSupId { get; set; }
        public long? ApprovedSupDate { get; set; }
        public int? ApprovedMgrId { get; set; }
        public long? ApprovedMgrDate { get; set; }
        [Required]
        public string Status { get; set; }

        // FKs
        [ForeignKey("InitiatedClerkId")]
        public Employee InitiatedClerk { get; set; }
        [ForeignKey("ApprovedSupId")]
        public Employee ApprovedSup { get; set; }
        [ForeignKey("ApprovedMgrId")]
        public Employee ApprovedMgr { get; set; }
    }
}
