using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class Retrieval
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ClerkId { get; set; }
        public long? DisbursedDate { get; set; }
        public long? RetrievedDate { get; set; }
        [Required]
        public string Status { get; set; }
        public string Remark { get; set; }
        public bool NeedAdjustment { get; set; }
        public List<RequisitionDetail> RequisitionDetails { get; set; }

        // FKs
        [ForeignKey("ClerkId")]
        public Employee Clerk { get; set; }
    }
}
