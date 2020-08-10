using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class PurchaseOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SupplierId { get; set; }
        public double TotalPrice { get; set; }
        public int OrderedByClerkId { get; set; }
        public long? OrderedDate { get; set; }
        public long SupplyByDate { get; set; }
        public int? ApprovedBySupId { get; set; }
        public int? ReceivedByClerkId { get; set; }
        public long? ReceivedDate { get; set; }
        public string Status { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual Employee OrderedByClerk { get; set; }
        public virtual Employee ApprovedBySup { get; set; }
        public virtual Employee ReceivedByClerk { get; set; }
        public virtual List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
