using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Models
{
    public class PurchaseRequestDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int PurchaseRequestId { get; set; }
        [Required]
        public int CreatedByClerkId { get; set; }
        [Required]
        public string ProductId { get; set; }
        [Required]
        public string SupplierId { get; set; }
        public int CurrentStock { get; set; }
        public int ReorderQty { get; set; }
        public string VenderQuote { get; set; } //Can't submit if null
        public double TotalPrice { get; set; }
        public long? SubmitDate { get; set; }
        public long? ApprovedDate { get; set; }
        public int? ApprovedBySupId { get; set; }
        [Required]
        public string Status { get; set; }
        public string Remarks { get; set; }

        // FKs
        [ForeignKey("CreatedByClerkId")]
        public Employee CreatedByClerk { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        [ForeignKey("ApprovedBySupId")]
        public Employee ApprovedBySup { get; set; }

        // Top 3 suppliers of selected item
        //[ForeignKey("SupplierId")]
        //public virtual List<Supplier> Suppliers { get; set; }
    }
}
