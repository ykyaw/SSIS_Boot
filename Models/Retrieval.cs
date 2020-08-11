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

        public int ClerkId { get; set; }
        public long? DisbursedDate { get; set; }
        public long? RetrievedDate { get; set; }

        public string Status { get; set; }
        public string Remark { get; set; }
        public bool NeedAdjustment { get; set; }
        public virtual List<RequisitionDetail> RequisitionDetails { get; set; }
        public virtual Employee Clerk { get; set; }
    }
}
