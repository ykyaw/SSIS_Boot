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
        [Required]
        public string SupplierId { get; set; }
        public double TotalPrice { get; set; }
        [Required]
        public int OrderedByClerkId { get; set; }
        public long? OrderedDate { get; set; }
        [Required]
        public long SupplyByDate { get; set; }
        public int? ApprovedBySupId { get; set; }
        public int? ReceivedByClerkId { get; set; }
        public long? ReceivedDate { get; set; }
        [Required]
        public string Status { get; set; }

        // FKs
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        [ForeignKey("OrderedByClerkId")]
        public Employee OrderedByClerk { get; set; }
        [ForeignKey("ApprovedBySupId")]
        public Employee ApprovedBySup { get; set; }
        [ForeignKey("ReceivedByClerkId")]
        public Employee ReceivedByClerk { get; set; }
    }
}
